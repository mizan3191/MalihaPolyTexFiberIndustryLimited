using DevSkill.Data;
using MalihaPolyTex.Academy.Contexts;
using MalihaPolyTex.Academy.Entities;

namespace MalihaPolyTex.Academy.Repositories
{
    public class DepartmentRepository : Repository<Department, int, AcademyDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(IAcademyDbContext academyDbContext)
            : base((AcademyDbContext)academyDbContext)
        {

        }
    }
}
