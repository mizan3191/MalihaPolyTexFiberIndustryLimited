using DevSkill.Data;
using MalihaPolyTex.Institute.Contexts;
using MalihaPolyTex.Institute.Entities;

namespace MalihaPolyTex.Institute.Repositories
{
    public class DepartmentRepository : Repository<Department, int, MalihaPolyTexDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(IMalihaPolyTexDbContext dbContext)
            : base((MalihaPolyTexDbContext)dbContext)
        {

        }
    }
}