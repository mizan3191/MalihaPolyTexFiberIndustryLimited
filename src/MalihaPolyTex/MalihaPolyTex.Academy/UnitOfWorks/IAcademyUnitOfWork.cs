using DevSkill.Data;
using MalihaPolyTex.Academy.Repositories;

namespace MalihaPolyTex.Academy.UnitOfWorks
{
    public interface IAcademyUnitOfWork : IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
    }
}