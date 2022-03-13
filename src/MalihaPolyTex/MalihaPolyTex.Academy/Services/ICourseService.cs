using MalihaPolyTex.Academy.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public interface ICourseService
    {
        Task CreateCourseAsync(Course course);
        Task<(IList<Course> records, int total, int totalDisplay)> CreateCourseAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task<Course> LoadCourseDataAsync(int id);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
        Task<IList<Course>> LoadCourseDataAsync();
    }
}