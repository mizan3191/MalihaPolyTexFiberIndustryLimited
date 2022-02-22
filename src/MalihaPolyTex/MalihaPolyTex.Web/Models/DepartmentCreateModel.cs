using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class DepartmentCreateModel
    {
        public int Id { get; set; }

        [Required]
        public string DeptName { get; set; }

        private ILifetimeScope _scope;
        private IDepartmentService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IDepartmentService>();

        }

        public DepartmentCreateModel(IDepartmentService service)
        {
            _service = service;
        }

        public DepartmentCreateModel()
        {

        }

        internal async Task CreateDepartmentAsync()
        {
            var dept = new Department()
            {
                DeptName = DeptName,
            };

            await _service.CreateDepartmentAsync(dept);
        }
    }
}