using Autofac;
using MalihaPolyTex.Institute.Services;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MalihaPolyTex.Web.Models
{
    public class CourseDataModel
    {
        private ILifetimeScope _scope;
        private ICourseService _service;

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<ICourseService>();

        }

        public CourseDataModel(ICourseService service)
        {
            _service = service;
        }

        public CourseDataModel()
        {

        }

        internal async Task<object> GetCourseListAsync(DataTablesAjaxRequestModel dataTable)
        {
            var data = await _service.GetCourseAsync(
                dataTable.PageIndex,
                dataTable.PageSize,
                dataTable.SearchText,
                dataTable.GetSortText(new string[] { "Title", "Fee", "SeatCount" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Title,
                            record.Fee.ToString(),
                            record.SeatCount.ToString(),
                            record.Id.ToString()
                        }
                    ).ToArray()
            };

        }
    }
}
