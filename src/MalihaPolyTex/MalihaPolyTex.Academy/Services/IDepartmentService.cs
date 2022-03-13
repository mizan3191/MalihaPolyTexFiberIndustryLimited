using MalihaPolyTex.Academy.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public interface IDepartmentService
    {
        Task CreateDepartmentAsync(Department department);
        Task<(IList<Department> records, int total, int totalDisplay)> DepartmentListAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task<Department> LoadDepartmentDataAsync(int id);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
        Task EnrollStudentAsync(Course selectedCourse, Student selectedStudent, StudentRegistration enroll);
        Task<IEnumerable<Department>> LoadDepartmentDataAsync();
    }
}