using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class StudentEditModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

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

        internal async Task LoadStudentAsync(int id)
        {
            Student student = await _service.LoadAsync(id);

            if(student != null)
            {
                Name = student.Name;
                DateOfBirth = student.DateOfBirth;
                DepartmentId = student.DepartmentId;
                Id= student.Id;
            }
        }

        internal async Task UpdateAsync()
        {
            Student student = new Student()
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                DepartmentId = DepartmentId,
                Id = Id
            };

            await _service.UpdateAsync(student);
        }
    }
}