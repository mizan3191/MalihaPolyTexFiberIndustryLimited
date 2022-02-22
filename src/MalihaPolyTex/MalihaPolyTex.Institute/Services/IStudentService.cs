using MalihaPolyTex.Institute.BusinessObjects;
using System.Collections.Generic;

namespace MalihaPolyTex.Institute.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
        (IList<Student> records, int total, int totalDisplay) GetStudent(
            int pageIndex, int pageSize, string searchText, string sortText);
    }
}