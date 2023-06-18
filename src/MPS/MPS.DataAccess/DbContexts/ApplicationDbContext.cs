using MPS.DataAccess.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MPS.DataAccess.Entities;

namespace MPS.DataAccess.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,
        Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Test> Tests { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProjectUser>().HasKey(c => new { c.ApplicationUserId, c.ProjectId });

        //    modelBuilder.Entity<ProjectUser>()
        //       .HasOne(x => x.Project)
        //       .WithMany(x => x.ProjectUsers)
        //       .HasForeignKey(x => x.ProjectId);

        //    modelBuilder.Entity<ProjectUser>()
        //        .HasOne(x => x.ApplicationUser)
        //        .WithMany(x => x.UserProjects)
        //        .HasForeignKey(x => x.ApplicationUserId);

        //    modelBuilder.Entity<Activity>()
        //        .HasOne<ScreenCapture>(s => s.ScreenCapture)
        //        .WithOne(ad => ad.Activity)
        //        .HasForeignKey<ScreenCapture>(ad => ad.ActivityId);

        //    modelBuilder.Entity<Activity>()
        //       .HasOne<WebcamCapture>(s => s.WebcamCapture)
        //       .WithOne(ad => ad.Activity)
        //       .HasForeignKey<WebcamCapture>(ad => ad.ActivityId);

        //    modelBuilder.Entity<Activity>()
        //       .HasMany<ActiveWindows>(s => s.ActiveWindows)
        //       .WithOne(ad => ad.Activity)
        //       .HasForeignKey(ad => ad.ActivityId);

        //    modelBuilder.Entity<Activity>()
        //       .HasMany<RunningProgram>(s => s.RunningPrograms)
        //       .WithOne(ad => ad.Activity)
        //       .HasForeignKey(ad => ad.ActivityId);

        //    modelBuilder.Entity<Activity>()
        //       .HasOne<MouseActivities>(s => s.MouseActivity)
        //       .WithOne(ad => ad.Activity)
        //       .HasForeignKey<MouseActivities>(ad => ad.ActivityId);

        //    modelBuilder.Entity<Activity>()
        //       .HasOne<KeyboardActivities>(s => s.KeyboardActivity)
        //       .WithOne(ad => ad.Activity)
        //       .HasForeignKey<KeyboardActivities>(ad => ad.ActivityId);

        //    modelBuilder.Entity<Project>()
        //       .HasMany<Invitation>(s => s.Invitations)
        //       .WithOne(ad => ad.Project)
        //       .HasForeignKey(ad => ad.ProjectId);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}