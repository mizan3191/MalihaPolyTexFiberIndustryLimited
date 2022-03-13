using DevSkill.Data;
using MalihaPolyTex.Academy.Contexts;
using MalihaPolyTex.Academy.Repositories;

namespace MalihaPolyTex.Academy.UnitOfWorks
{
    public class AcademyUnitOfWork : UnitOfWork, IAcademyUnitOfWork
    {
        public IStudentRepository StudentRepository { get; private set; }
        public ICourseRepository CourseRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public AcademyUnitOfWork(IAcademyDbContext academyDbContext, 
            IStudentRepository studentRepository,
            ICourseRepository courseRepository, 
            IDepartmentRepository departmentRepository)
           : base((AcademyDbContext)academyDbContext)
        {
            StudentRepository = studentRepository;
            CourseRepository = courseRepository;
            DepartmentRepository = departmentRepository;
        }
    }
}