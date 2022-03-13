using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using MalihaPolyTex.Academy.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.DepartmentModel
{
    public class EnrollModel
    {
        public string Title { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool IsPaymentComplete { get; set; }

        private ILifetimeScope _scope;
        private ICourseService _courseService;
        private IStudentService _studentService;
        private IDepartmentService _departmentService;
        private IDateTimeUtility _dateTimeUtility;
        public EnrollModel()
        {

        }

        public EnrollModel(IDepartmentService departmentService, IDateTimeUtility dateTimeUtility,
            ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _dateTimeUtility = dateTimeUtility;
            _departmentService = departmentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
            _studentService = _scope.Resolve<IStudentService>();
            _dateTimeUtility = _scope.Resolve<IDateTimeUtility>();
            _departmentService = _scope.Resolve<IDepartmentService>();
        }

        public async Task EnrollStudentAsync()
        {
            var course = await _courseService.LoadCourseDataAsync();
            var student = await _studentService.LoadStudentDataAsync();
            var selectedCourse = course.Where(x => x.Id == CourseId).FirstOrDefault();
            var selectedStudent = student.Where(x => x.Id == StudentId).FirstOrDefault();

            var enroll = new StudentRegistration()
            {
                StudentId = StudentId,
                CourseId = CourseId,
                EnrollDate = _dateTimeUtility.Now,
                IsPaymentComplete = IsPaymentComplete
            };

            await _departmentService.EnrollStudentAsync(selectedCourse, selectedStudent, enroll);
        }
    }
}
