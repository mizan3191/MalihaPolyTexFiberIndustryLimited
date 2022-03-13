using DevSkill.Data;
using MalihaPolyTex.Academy.Contexts;
using MalihaPolyTex.Academy.Entities;
namespace MalihaPolyTex.Academy.Repositories
{
    public class StudentRepository : Repository<Student, int, AcademyDbContext> ,IStudentRepository
    {
        public StudentRepository(IAcademyDbContext academyDbContext)
            : base((AcademyDbContext) academyDbContext)
        {

        }
    }
}