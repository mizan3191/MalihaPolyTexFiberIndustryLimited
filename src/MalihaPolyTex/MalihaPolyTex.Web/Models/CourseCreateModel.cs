using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class CourseCreateModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }

        private ILifetimeScope _scope;
        private ICourseService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<ICourseService>();

        }

        public CourseCreateModel(ICourseService service)
        {
            _service = service;
        }

        public CourseCreateModel()
        {

        }

        internal async Task CreateAsync()
        {
            var course = new Course()
            {
                Title = Title,
                Fee = Fee,
                SeatCount = SeatCount,
            };

            await _service.CreateAsync(course);
        }

        internal async Task DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}