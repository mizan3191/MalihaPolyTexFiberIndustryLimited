using Autofac;
using MalihaPolyTex.Institute.Services;
using System;
using System.Linq;

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

        internal object GetStudentList(DataTablesAjaxRequestModel ajax)
        {
            var data = _service.GetStudent(
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
    }
}
