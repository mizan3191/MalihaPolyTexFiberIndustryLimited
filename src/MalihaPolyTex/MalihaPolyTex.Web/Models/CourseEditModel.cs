using Autofac;
using MalihaPolyTex.Institute.Services;

namespace MalihaPolyTex.Web.Models
{
    public class CourseEditModel
    {
        private ILifetimeScope _scope;
        private ICourseService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<ICourseService>();

        }

        public CourseEditModel(ICourseService service)
        {
            _service = service;
        }

        public CourseEditModel()
        {

        }
    }
}
