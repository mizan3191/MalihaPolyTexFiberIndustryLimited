using Autofac;
using MalihaPolyTex.Institute.Contexts;
using MalihaPolyTex.Institute.Repositories;
using MalihaPolyTex.Institute.Services;
using MalihaPolyTex.Institute.UnitOfWorks;
using System;

namespace MalihaPolyTex.Institute
{
    public class MalihaPolyTexModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MalihaPolyTexModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MalihaPolyTexDbContext>().AsSelf()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<MalihaPolyTexDbContext>().As< IMalihaPolyTexDbContext > ()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();

            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();

            builder.RegisterType<MalihaPolyTexUnitOfWork>().As<IMalihaPolyTexUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
