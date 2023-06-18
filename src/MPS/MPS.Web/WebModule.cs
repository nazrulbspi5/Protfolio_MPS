using Autofac;
using MPS.Web.Models;
namespace MPS.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginModel>().AsSelf();

            builder.RegisterType<RegisterModel>().AsSelf();

            base.Load(builder);
        }
    }
}
