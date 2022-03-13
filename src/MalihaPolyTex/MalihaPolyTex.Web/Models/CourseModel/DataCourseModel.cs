using Autofac;
using MalihaPolyTex.Academy.Services;
using MalihaPolyTex.Academy.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Web.Models.CourseModel
{
    public class DataCourseModel
    {
        private ICourseService _courseService;
        private ILifetimeScope _scope;

        public DataCourseModel()
        {

        }
        public DataCourseModel(ICourseService courseService, ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = courseService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _courseService = _scope.Resolve<ICourseService>();
        }
        public async Task<object> CourseListAsync(DataTablesAjaxRequestModel dataTable)
        {
            var data = await _courseService.CreateCourseAsync(
                dataTable.PageIndex,
                dataTable.PageSize,
                dataTable.SearchText,
                dataTable.GetSortText(new string[] {"Title","fee", "SeatCount" }));

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
                        }).ToList()
            };
        }

        internal async Task DeleteCourseAsync(int id)
        {
            await _courseService.DeleteCourseAsync(id);
        }
    }
}