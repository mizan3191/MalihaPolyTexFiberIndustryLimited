using MalihaPolyTex.Institute.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public interface IStudentService
    {
        Task CreateStudentAsync(Student student);
       Task< (IList<Student> records, int total, int totalDisplay)> GetStudentAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task<Student> LoadAsync(int id);
        Task UpdateAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}