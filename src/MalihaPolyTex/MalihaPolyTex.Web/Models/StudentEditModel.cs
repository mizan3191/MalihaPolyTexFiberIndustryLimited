using Autofac;
using MalihaPolyTex.Institute.Services;

namespace MalihaPolyTex.Web.Models
{
    public class StudentEditModel
    {
        private ILifetimeScope _scope;
        private IStudentService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IStudentService>();

        }

        public StudentEditModel(IStudentService service)
        {
            _service = service;
        }

        public StudentEditModel()
        {

        }
    }
}
