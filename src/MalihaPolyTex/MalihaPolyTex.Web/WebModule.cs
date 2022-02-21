using Autofac;
using MalihaPolyTex.Web.Models;

namespace MalihaPolyTex.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentCreateModel>().AsSelf();
            builder.RegisterType<CourseCreateModel>().AsSelf();

            base.Load(builder);
        }
    }
}