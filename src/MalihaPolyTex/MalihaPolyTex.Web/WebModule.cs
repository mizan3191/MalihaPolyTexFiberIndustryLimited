using Autofac;
using MalihaPolyTex.Web.Models;
using MalihaPolyTex.Web.Models.CourseModel;
using MalihaPolyTex.Web.Models.Demo;
using MalihaPolyTex.Web.Models.DepartmentModel;
using MalihaPolyTex.Web.Models.StudentModel;

namespace MalihaPolyTex.Web
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public WebModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateDepartmentModel>().AsSelf();
            builder.RegisterType<DataDepartmentModel>().AsSelf();
            builder.RegisterType<EditDepartmentModel>().AsSelf();
            builder.RegisterType<EnrollModel>().AsSelf();

            builder.RegisterType<CreateCourseModel>().AsSelf();
            builder.RegisterType<DataCourseModel>().AsSelf();
            builder.RegisterType<EditCourseModel>().AsSelf();

            builder.RegisterType<CreateStudentModel>().AsSelf();
            builder.RegisterType<DataStudentModel>().AsSelf();
            builder.RegisterType<EditStudentModel>().AsSelf();

            builder.RegisterType<FormModel>().AsSelf();


            builder.RegisterType<DatabaseContext>().AsSelf();
            builder.RegisterType<SubCategory>().AsSelf();
            builder.RegisterType<MainProduct>().AsSelf();
            builder.RegisterType<Category>().AsSelf();

            base.Load(builder);
        }
    }
}