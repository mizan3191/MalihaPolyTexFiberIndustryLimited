using DevSkill.Data;
using MalihaPolyTex.Institute.Repositories;

namespace MalihaPolyTex.Institute.UnitOfWorks
{
    public interface IMalihaPolyTexUnitOfWork :IUnitOfWork
    {
        public IStudentRepository StudentRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
    }
}