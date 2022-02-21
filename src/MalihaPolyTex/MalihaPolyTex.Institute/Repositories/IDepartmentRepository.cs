using DevSkill.Data;
using MalihaPolyTex.Institute.Contexts;
using MalihaPolyTex.Institute.Entities;

namespace MalihaPolyTex.Institute.Repositories
{
    public interface IDepartmentRepository : IRepository<Department, int, MalihaPolyTexDbContext>
    {
    }
}