using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.CourseModel
{
    public class CreateCourseModel
    {
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }

        private ICourseService _courseService;
        private ILifetimeScope _scope;

        public CreateCourseModel()
        {

        }
        public CreateCourseModel(ICourseService courseService, ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = courseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
        }

        public async Task CreateCourseAsync()
        {
            var course = new Course()
            {
                Title = Title,
                SeatCount = SeatCount,
                Fee = Fee
            };

            await _courseService.CreateCourseAsync(course);
        }
    }
}