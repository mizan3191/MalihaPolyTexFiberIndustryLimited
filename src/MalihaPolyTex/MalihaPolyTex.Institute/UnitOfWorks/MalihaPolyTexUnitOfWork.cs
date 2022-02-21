using DevSkill.Data;
using MalihaPolyTex.Institute.Contexts;
using MalihaPolyTex.Institute.Repositories;

namespace MalihaPolyTex.Institute.UnitOfWorks
{
    public class MalihaPolyTexUnitOfWork : UnitOfWork, IMalihaPolyTexUnitOfWork
    {
        public IStudentRepository StudentRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }

        public MalihaPolyTexUnitOfWork(IMalihaPolyTexDbContext dbContext,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IDepartmentRepository departmentRepository)
            : base((MalihaPolyTexDbContext)dbContext)
        {
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }
    }
}