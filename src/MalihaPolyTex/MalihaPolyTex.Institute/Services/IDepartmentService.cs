using MalihaPolyTex.Institute.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(Department dept);
        Task<(IList<Department> records, int total, int totalDisplay)> GetDepartmentAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task<Department> LoadDataAsync(int id);
        Task UpdateAsync(Department department);
        Task DeleteAsync(int id);
    }
}