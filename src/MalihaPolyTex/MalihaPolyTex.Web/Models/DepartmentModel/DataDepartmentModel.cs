using Autofac;
using MalihaPolyTex.Academy.Services;
using MalihaPolyTex.Academy.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.DepartmentModel
{
    public class DataDepartmentModel
    {
        private ILifetimeScope _scope;
        private IDepartmentService _departmentService;

        public DataDepartmentModel()
        {

        }
        public DataDepartmentModel(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _departmentService = _scope.Resolve<IDepartmentService>();
        }
        public async Task<object> DepartmentListAsync(DataTablesAjaxRequestModel dataTable)
        {
            var data = await _departmentService.DepartmentListAsync(
                dataTable.PageIndex,
                dataTable.PageSize,
                dataTable.SearchText,
                dataTable.GetSortText(new string[] { "DeptName" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.DeptName,
                            record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
        }
    }
}