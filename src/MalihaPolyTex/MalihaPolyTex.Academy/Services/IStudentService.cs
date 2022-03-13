using MalihaPolyTex.Academy.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public interface IStudentService
    {
        Task CreateStudentAsync(Student student);
        Task<(IList<Student> records, int total, int totalDisplay)> StudentListAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task<Student> LoadStudentDataAsync(int id);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<IList<Student>> LoadStudentDataAsync();
    }
}