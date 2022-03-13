using DevSkill.Data;
using MalihaPolyTex.Academy.Contexts;
using MalihaPolyTex.Academy.Entities;

namespace MalihaPolyTex.Academy.Repositories
{
    internal class CourseRepository : Repository<Course, int, AcademyDbContext>, ICourseRepository
    {
        public CourseRepository(IAcademyDbContext academyDbContext)
            : base((AcademyDbContext)academyDbContext)
        {

        }
    }
}