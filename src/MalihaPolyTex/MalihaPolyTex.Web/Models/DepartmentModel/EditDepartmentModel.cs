using Autofac;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.Services;
using System;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.DepartmentModel
{
    public class EditDepartmentModel
    {
        public int Id { get; set; }
        public string DeptName { get; set; }

        private ILifetimeScope _scope;
        private IDepartmentService _departmentService;
        public EditDepartmentModel()
        {

        }
        public EditDepartmentModel(ILifetimeScope scope, IDepartmentService departmentService)
        {
            _scope = scope;
            _departmentService = departmentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _departmentService = _scope.Resolve<IDepartmentService>();
        }

        public async Task LoadDepartmentDataAsync(int id)
        {
            var department = await _departmentService.LoadDepartmentDataAsync(id);

            if(department != null)
            {
                Id = department.Id;
                DeptName = department.DeptName;
            }
        }

        public async Task UpdateDepartmentAsync()
        {
            var department = new Department()
            {
                Id = Id,
                DeptName = DeptName
            };

            await _departmentService.UpdateDepartmentAsync(department);
        }
    }
}