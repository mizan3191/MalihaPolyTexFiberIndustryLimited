using MalihaPolyTex.Institute.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public interface ICourseService
    {
        Task<(IList<Course> records, int total, int totalDisplay)> GetCourseAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task CreateAsync(Course course);
        Task<Course> LoadDataAsync(int id);
        Task UpdateAsync(Course courseData);
        Task DeleteAsync(int id);
    }
}