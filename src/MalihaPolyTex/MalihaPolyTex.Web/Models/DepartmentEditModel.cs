using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class DepartmentEditModel
    {
        public int Id { get; set; }
        public string DeptName { get; set; }

        private ILifetimeScope _scope;
        private IDepartmentService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IDepartmentService>();

        }

        public DepartmentEditModel(IDepartmentService service)
        {
            _service = service;
        }

        public DepartmentEditModel()
        {

        }

        internal async Task LoadDataAsync(int id)
        {
            var department = await _service.LoadDataAsync(id);

            if (department != null)
            {
                DeptName = department.DeptName;
                Id = department.Id;
            }
        }

        internal async Task UpdateAsync()
        {
            var department = new Department()
            {
                DeptName = DeptName,
                Id = Id
            };

           await _service.UpdateAsync(department);
        }
    }
}