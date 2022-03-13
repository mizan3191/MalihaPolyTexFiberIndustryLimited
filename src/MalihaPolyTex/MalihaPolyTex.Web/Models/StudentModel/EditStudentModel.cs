using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.StudentModel
{
    public class EditStudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
        public DateTime DateOfBirth { get; set; }

        private ILifetimeScope _scope;
        private IStudentService _studentService;
        public EditStudentModel()
        {

        }
        public EditStudentModel(ILifetimeScope scope, IStudentService studentService)
        {
            _scope = scope;
            _studentService = studentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
        }
        public async Task LoadStudentDataAsync(int id)
        {
            var studet = await _studentService.LoadStudentDataAsync(id);
            if(studet != null)
            {
                Id = studet.Id;
                Name = studet.Name;
                DeptId = studet.DeptId;
                DateOfBirth = studet.DateOfBirth;
            }
        }
        public async Task UpdateStudentAsync()
        {
            var student = new Student()
            {
                Id = Id,
                Name = Name,
                DeptId = DeptId,
                DateOfBirth = DateOfBirth,
            };
            await _studentService.UpdateStudentAsync(student);
        }
    }
}