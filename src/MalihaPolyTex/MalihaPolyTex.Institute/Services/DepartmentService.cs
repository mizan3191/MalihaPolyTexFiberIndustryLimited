using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IMalihaPolyTexUnitOfWork _unitOfWork;

        public DepartmentService(IMalihaPolyTexUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDepartmentAsync(Department dept)
        {
            await _unitOfWork.DepartmentRepository.AddAsync(
                new Entities.Department { DeptName = dept.DeptName });

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if(id > 0)
            {
                await _unitOfWork.DepartmentRepository.RemoveAsync(id);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<(IList<Department> records, int total, int totalDisplay)> GetDepartmentAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var list = await _unitOfWork.DepartmentRepository.GetDynamicAsync(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.DeptName.Contains(searchText),
                sortText, null, pageIndex, pageSize);

            var result = (from datalist in list.data
                          select new Department()
                          {
                              DeptName = datalist.DeptName,
                              Id = datalist.Id,
                          }).ToList();

            return(result, list.total, list.totalDisplay);
        }

        public async Task<Department> LoadDataAsync(int id)
        {
            var entity = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);

            if(entity == null)
                throw new Exception("Course id Doesn't finding");

            return new Department
            {
                DeptName = entity.DeptName,
                Id= entity.Id,
            };
        }

        public async Task UpdateAsync(Department department)
        {
            var entity = await _unitOfWork.DepartmentRepository.GetByIdAsync(department.Id);

            if( entity != null)
            {
                entity.DeptName = department.DeptName;
                await _unitOfWork.SaveAsync();
            }
        }
    }
}