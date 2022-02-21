using DevSkill.Data;
using MalihaPolyTex.Institute.Contexts;
using MalihaPolyTex.Institute.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Repositories
{
    public class StudentRepository : Repository<Student, int, MalihaPolyTexDbContext>, IStudentRepository
    {
        public StudentRepository(IMalihaPolyTexDbContext dbContext)
            : base((MalihaPolyTexDbContext)dbContext)
        {

        }
    }
}
