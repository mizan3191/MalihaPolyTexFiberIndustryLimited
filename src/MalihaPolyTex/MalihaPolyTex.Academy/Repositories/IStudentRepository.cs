using DevSkill.Data;
using MalihaPolyTex.Academy.Contexts;
using MalihaPolyTex.Academy.Entities;

namespace MalihaPolyTex.Academy.Repositories
{
    public interface IStudentRepository : IRepository<Student, int, AcademyDbContext>
    {
    }
}