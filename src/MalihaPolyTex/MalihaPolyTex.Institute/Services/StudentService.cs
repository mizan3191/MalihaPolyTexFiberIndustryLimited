using AutoMapper;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public class StudentService : IStudentService
    {
        private IMalihaPolyTexUnitOfWork _unitOfWork;
        

        public StudentService(IMalihaPolyTexUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateStudent(Student student)
        {
            _unitOfWork.StudentRepository.Add(
                new Entities.Student()
                {
                    Name = student.Name,
                    DateOfBirth = student.DateOfBirth,
                    DepartmentId = student.DepartmentId,
                });

            _unitOfWork.Save();
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudent(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentData = _unitOfWork.StudentRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, null, pageIndex, pageSize);

            var resultData = (from student in studentData.data
                              select new Student()
                              {
                                  Name = student.Name,
                                  DateOfBirth = student.DateOfBirth,
                                  DepartmentId = student.DepartmentId,
                                  Id = student.Id
                              }).ToList();

            return (resultData, studentData.total, studentData.totalDisplay);
        }
    }
}