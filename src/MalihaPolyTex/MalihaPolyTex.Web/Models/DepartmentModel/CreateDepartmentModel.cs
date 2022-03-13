using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.DepartmentModel
{
    public class CreateDepartmentModel
    {
        [Required]
        public string DeptName { get; set; }

        private ILifetimeScope _scope;
        private IDepartmentService _departmentService;
    

        public CreateDepartmentModel()
        {

        }

        public CreateDepartmentModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _departmentService = _scope.Resolve<IDepartmentService>();
        }
        public async Task CerateDepartmentAsync()
        {
            var department = new Department()
            {
                DeptName = DeptName
            };

            await _departmentService.CreateDepartmentAsync(department);
        }
    }
}