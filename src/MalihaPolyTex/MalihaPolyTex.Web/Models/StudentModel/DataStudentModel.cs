using Autofac;
using MalihaPolyTex.Academy.Services;
using MalihaPolyTex.Academy.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.StudentModel
{
    public class DataStudentModel
    {
        private ILifetimeScope _scope;
        private IStudentService _studentService;

        public DataStudentModel()
        {

        }
        public DataStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _studentService = _scope.Resolve<IStudentService>();
        }
        public async Task<Object> StudentListAsync(DataTablesAjaxRequestModel dataTable)
        {
            var data = await _studentService.StudentListAsync(
                dataTable.PageIndex, 
                dataTable.PageSize,
                dataTable.SearchText,
                dataTable.GetSortText(new string[] { "Name", "DeptId", "DateOfBirth" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.DeptId.ToString(),
                            record.DateOfBirth.ToString(),
                            record.Id.ToString()
                        }).ToList(),
            };
        }
        public async Task DeleteStudentAsync(int id)
        {
            await _studentService.DeleteStudentAsync(id);
        }
    }
}