using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class CourseEditModel
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

        public CourseEditModel(ICourseService service)
        {
            _service = service;
        }

        public CourseEditModel()
        {

        }

        internal async Task LoadCourseAsync(int id)
        {
            Course coursedata = await _service.LoadDataAsync(id);

            if(coursedata != null)
            {
                Title = coursedata.Title;
                Fee = coursedata.Fee;
                SeatCount = coursedata.SeatCount;
                Id = coursedata.Id;
            }
        }

        internal async Task UpdateAsync()
        {
            var courseData = new Course()
            {
                Title = Title,
                Fee = Fee,
                SeatCount = SeatCount,
                Id = Id
            };

            await _service.UpdateAsync(courseData);
        }
    }
}