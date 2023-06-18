using Autofac;
using MPS.DataAccess.DbContexts;
using MPS.DataAccess.Repositories;
using MPS.Services.Services;
using MPS.Services.Services.Membership;

namespace MPS.Services
{
    public class ServicesModule : Module
    {
       
        protected override void Load(ContainerBuilder builder)
        {
          
            builder.RegisterType<ApplicationUserManager>().AsSelf();

            builder.RegisterType<ApplicationSignInManager>().AsSelf();

            builder.RegisterType<ApplicationRoleManager>().AsSelf();

            builder.RegisterType<TestService>()
               .As<ITestService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}