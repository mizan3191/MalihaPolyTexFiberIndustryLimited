using AutoMapper;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CreateStudentAsync(Student student)
        {
            await _unitOfWork.StudentRepository.AddAsync(
                new Entities.Student()
                {
                    Name = student.Name,
                    DateOfBirth = student.DateOfBirth,
                    DepartmentId = student.DepartmentId,
                });

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            if(id.ToString() != null)
            {
                await _unitOfWork.StudentRepository.RemoveAsync(id);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task< (IList<Student> records, int total, int totalDisplay)> GetStudentAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentData = await _unitOfWork.StudentRepository.GetDynamicAsync(
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

        public async Task<Student> LoadAsync(int id)
        {
            var entity = await _unitOfWork.StudentRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Student doesn't exist");

            return new Student()
            {
                Id = entity.Id,
                Name = entity.Name,
                DepartmentId = entity.DepartmentId,
                DateOfBirth = entity.DateOfBirth
            };
        }

        public async Task UpdateAsync(Student student)
        {
            var entity = await _unitOfWork.StudentRepository.GetByIdAsync(student.Id);

            if(entity != null)
            {
                entity.DateOfBirth = student.DateOfBirth;
                entity.DepartmentId = student.DepartmentId;
                entity.Name= student.Name;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}