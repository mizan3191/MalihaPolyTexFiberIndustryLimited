using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MalihaPolyTex.Web.Models
{
    public class FormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public int DeptId { get; set; }
        public string Title { get; set; }
        public bool IsPaymentComplete { get; set; }
        public IEnumerable<Student> StudentList { get; set; }
        public IEnumerable<Department> DepartmentList { get; set; }
        public IList<Course> CourseList { get; set; }

        private IStudentService _studentService { get; set; }
        private IDepartmentService _departmentService { get; set; }
        private ICourseService _courseService { get; set; }

        private ILifetimeScope _scope;
        internal object createList;

        public FormModel()
        {

        }
        public FormModel(IStudentService studentService, ICourseService courseService, 
            IDepartmentService departmentService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _departmentService = departmentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
            _studentService = _scope.Resolve<IStudentService>();
            _departmentService = _scope.Resolve<IDepartmentService>();
        }
        public async Task LoadStudenDataAsync()
        {
            StudentList = await _studentService.LoadStudentDataAsync();
            CourseList = await _courseService.LoadCourseDataAsync();
            DepartmentList = await _departmentService.LoadDepartmentDataAsync();
        }

        internal async Task DeptList(int studentId)
        {
            var student = await _studentService.LoadStudentDataAsync(studentId);
            var deptName = await _departmentService.LoadDepartmentDataAsync(student.DeptId);

            if(deptName != null)
            {
                DeptName = deptName.DeptName;
                DeptId = deptName.Id;
            }
        }
    }
}