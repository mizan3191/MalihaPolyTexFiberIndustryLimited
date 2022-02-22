using Autofac;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class DepartmentDataModel
    {
        private ILifetimeScope _scope;
        private IDepartmentService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IDepartmentService>();

        }

        public DepartmentDataModel(IDepartmentService service)
        {
            _service = service;
        }

        public DepartmentDataModel()
        {

        }

        internal async Task<object> GetDepartmentListAsync(DataTablesAjaxRequestModel dataTable)
        {
            var data = await _service.GetDepartmentAsync(
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

        internal async Task DeleteAsync(int id)
        {
            if(id.ToString() != null)
            {
                await _service.DeleteAsync(id);
            }
        }
    }
}