using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IAcademyUnitOfWork _unitOfWork;
        public DepartmentService(IAcademyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            await _unitOfWork.DepartmentRepository.AddAsync(
                new Entities.Department() 
                { 
                    DeptName = department.DeptName
                });
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _unitOfWork.DepartmentRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Department> records, int total, int totalDisplay)> DepartmentListAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var departmentList = await _unitOfWork.DepartmentRepository.GetDynamicAsync(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.DeptName.Contains(searchText),
                sortText, null, pageIndex, pageSize);

            var result = (from data in departmentList.data
                          select new Department()
                          {
                              DeptName = data.DeptName,
                              Id = data.Id,
                          }).ToList();

            return (result, departmentList.total, departmentList.totalDisplay);
        }

        public async Task EnrollStudentAsync(Course selectedCourse, Student selectedStudent, 
            StudentRegistration enroll)
        {
            var courseEntity = await _unitOfWork.CourseRepository.GetByIdAsync(selectedCourse.Id);
            var studentEntity = await _unitOfWork.StudentRepository.GetByIdAsync(selectedStudent.Id);

            if (courseEntity == null)
                throw new InvalidOperationException("Course was not found");
            if (courseEntity.EnrollStudents == null)
            {
                courseEntity.EnrollStudents = new List<Entities.StudentRegistration>();
            }

            courseEntity.EnrollStudents.Add(new Entities.StudentRegistration()
            {
                IsPaymentComplete = enroll.IsPaymentComplete,
                EnrollDate = enroll.EnrollDate,
                CourseId = enroll.CourseId,
                StudentId = enroll.StudentId
            });

            await _unitOfWork.SaveAsync();
        }

        public async Task<Department> LoadDepartmentDataAsync(int id)
        {
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);
            if (department == null) return null;

            return new Department()
            {
                Id = department.Id,
                DeptName= department.DeptName
            };
        }

        public async Task<IEnumerable<Department>> LoadDepartmentDataAsync()
        {
            var DepartmentList = new List<Department>();
            var departmentEntity = await _unitOfWork.DepartmentRepository.GetAllAsync();

            if (departmentEntity == null) return null;

            foreach(var dept in departmentEntity)
            {
                var department = new Department()
                {
                    DeptName = dept.DeptName,
                    Id = dept.Id
                };

                DepartmentList.Add(department);
            }

            return DepartmentList;
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            if (department == null)
                throw new InvalidOperationException("Department missing");

            var deptEntity = await _unitOfWork.DepartmentRepository.GetByIdAsync(department.Id);

            if (deptEntity != null)
            {
                deptEntity.Id = department.Id;
                deptEntity.DeptName = department.DeptName;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}