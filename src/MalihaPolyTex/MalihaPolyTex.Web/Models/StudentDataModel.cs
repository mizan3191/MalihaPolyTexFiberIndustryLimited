using Autofac;
using MalihaPolyTex.Institute.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models
{
    public class StudentDataModel
    {
        private ILifetimeScope _scope;
        private IStudentService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IStudentService>();

        }

        public StudentDataModel(IStudentService service)
        {
            _service = service;
        }

        public StudentDataModel()
        {

        }

        internal async Task< object> GetStudentListAsync(DataTablesAjaxRequestModel ajax)
        {
            var data = await _service.GetStudentAsync(
               ajax.PageIndex,
               ajax.PageSize,
               ajax.SearchText,
               ajax.GetSortText(new string[] { "Name", "DepartmentId", "DateOfBirth" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.DepartmentId.ToString(),
                                record.DateOfBirth.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        internal async Task DeleteAsync(int id)
        {
            await _service.DeleteStudentAsync(id);
        }
    }
}