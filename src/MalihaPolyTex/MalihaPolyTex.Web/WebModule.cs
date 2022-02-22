using Autofac;
using MalihaPolyTex.Web.Models;

namespace MalihaPolyTex.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentCreateModel>().AsSelf();
            builder.RegisterType<StudentDataModel>().AsSelf();
            builder.RegisterType<StudentEditModel>().AsSelf();

            builder.RegisterType<CourseCreateModel>().AsSelf();
            builder.RegisterType<CourseDataModel>().AsSelf();
            builder.RegisterType<CourseEditModel>().AsSelf();

            builder.RegisterType<DepartmentCreateModel>().AsSelf();
            builder.RegisterType<DepartmentDataModel>().AsSelf();
            builder.RegisterType<DepartmentEditModel>().AsSelf();

            base.Load(builder);
        }
    }
}