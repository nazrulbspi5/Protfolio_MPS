using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using System.Text;
using System.Threading.Tasks;
using MPS.DataAccess.DbContexts;
using MPS.DataAccess.UnitOfWorks;
using MPS.DataAccess.Repositories;

namespace MPS.DataAccess
{
    public class DataAccessModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DataAccessModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<ApplicationUnitOfWork>()
                .As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TestRepository>()
                .As<ITestRepository>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
