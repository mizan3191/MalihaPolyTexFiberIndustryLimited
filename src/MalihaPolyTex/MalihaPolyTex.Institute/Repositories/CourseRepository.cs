using DevSkill.Data;
using MalihaPolyTex.Institute.Contexts;
using MalihaPolyTex.Institute.Entities;

namespace MalihaPolyTex.Institute.Repositories
{
    public class CourseRepository : Repository<Course, int, MalihaPolyTexDbContext>, ICourseRepository
    {
        public CourseRepository(IMalihaPolyTexDbContext dbContext)
            : base((MalihaPolyTexDbContext)dbContext)
        {

        }
    }
}