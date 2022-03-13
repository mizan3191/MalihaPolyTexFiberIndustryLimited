using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.CourseModel
{
    public class EditCourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SeatCount { get; set; }
        public int Fee { get; set; }

        private ICourseService _courseService;
        private ILifetimeScope _scope;

        public EditCourseModel()
        {

        }
        public EditCourseModel(ICourseService courseService, ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = courseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
        }
        public async Task LoadCourseDataAsync(int id)
        {
            var course = await _courseService.LoadCourseDataAsync(id);

            if (course != null)
            {
                Id = course.Id;
                Title = course.Title;
                SeatCount = course.SeatCount;
                Fee = course.Fee;
            }
        }

        internal async Task UpdateCourseAsync()
        {
            var course = new Course()
            {
                Id = Id,
                Title = Title,
                Fee = Fee,
                SeatCount = SeatCount
            };

            await _courseService.UpdateCourseAsync(course);
        }
    }
}