using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MPS.DataAccess;
using MPS.Web;
//using MPS.Web.Data;
using MPS.DataAccess.DbContexts;
using Serilog;
using Serilog.Events;
using System.Reflection;
using MPS.DataAccess.Entities.Membership;
using MPS.Services.Services.Membership;
using Microsoft.AspNetCore.Authentication.Cookies;
using MPS.Services;

var builder = WebApplication.CreateBuilder(args);

// Serilog configure
builder.Host.UseSerilog((ctx, lc) => lc
   .MinimumLevel.Debug()
   .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
   .Enrich.FromLogContext()
   .ReadFrom.Configuration(builder.Configuration));


try
{
    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("MPSConnection");
    var assemblyName = Assembly.GetExecutingAssembly().FullName;

    //Autofac configuration
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
         containerBuilder.RegisterModule(new WebModule());
         containerBuilder.RegisterModule(new ServicesModule());
        containerBuilder.RegisterModule(new DataAccessModule(connectionString, assemblyName));
    });

    // Add services to the container.
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //    options.UseSqlServer(connectionString));
    //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    //    .AddEntityFrameworkStores<ApplicationDbContext>();
   
    
    


    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services
            .AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserManager<ApplicationUserManager>()
            .AddRoleManager<ApplicationRoleManager>()
            .AddSignInManager<ApplicationSignInManager>()
            .AddDefaultTokenProviders();

    builder.Services.AddAuthentication()
      .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => {
          options.LoginPath = new PathString("/Account/Login");
          options.AccessDeniedPath = new PathString("/Account/Login");
          options.LogoutPath = new PathString("/Account/Logout");
          options.Cookie.Name = "MPS.Identity"; //We can customize cookie name
          options.SlidingExpiration = true;
          options.ExpireTimeSpan = TimeSpan.FromHours(1);
      });

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminPolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireRole("Admin");
        });


    });
    builder.Services.AddControllersWithViews();
    var app = builder.Build();
    Log.Information("Application Start");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application Start-up Failed");
}
finally
{
    Log.CloseAndFlush();
}