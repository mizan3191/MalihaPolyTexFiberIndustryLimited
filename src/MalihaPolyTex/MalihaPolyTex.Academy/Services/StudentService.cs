using AutoMapper;
using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public class StudentService : IStudentService
    {
        private readonly IAcademyUnitOfWork _unitOfWork;
        public StudentService(IAcademyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateStudentAsync(Student student)
        {
            await _unitOfWork.StudentRepository.AddAsync(
                new Entities.Student() 
                {
                    Name = student.Name,
                    DeptId = student.DeptId,
                    DateOfBirth = student.DateOfBirth,
                });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _unitOfWork.StudentRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Student> LoadStudentDataAsync(int id)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(id);
            if (student == null) return null;

            return new Student()
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth= student.DateOfBirth,
                DeptId = student.DeptId
            };
        }

        public async Task<IList<Student>> LoadStudentDataAsync()
        {
            var studentEntity = await _unitOfWork.StudentRepository.GetAllAsync();
            var students = new List<Student>();

            foreach (var entity in studentEntity)
            {
                var student = new Student()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DeptId = entity.DeptId,
                    DateOfBirth = entity.DateOfBirth
                };

                students.Add(student);
            }

            return students;
        }

        public async Task<(IList<Student> records, int total, int totalDisplay)> StudentListAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentList = await _unitOfWork.StudentRepository.GetDynamicAsync(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, null, pageIndex, pageSize);
            var result = (from data in studentList.data
                          select new Student()
                          {
                              Id = data.Id,
                              Name = data.Name,
                              DeptId = data.DeptId,
                              DateOfBirth = data.DateOfBirth
                          }).ToList();

            return (result, studentList.total, studentList.totalDisplay);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if (student == null)
                throw new InvalidOperationException("Student missing");

            var studentEntity = await _unitOfWork.StudentRepository.GetByIdAsync(student.Id);

            if(studentEntity != null)
            {
                studentEntity.Id = student.Id;
                studentEntity.Name = student.Name;
                studentEntity.DeptId = student.DeptId;
                studentEntity.DateOfBirth = student.DateOfBirth;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}