using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Institute.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public class CourseService : ICourseService
    {
        private IMalihaPolyTexUnitOfWork _unitOfWork;
        
        public CourseService(IMalihaPolyTexUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Course course)
        {
            await _unitOfWork.CourseRepository.AddAsync(
                new Entities.Course
                {
                    Fee = course.Fee,
                    SeatCount = course.SeatCount,
                    Title = course.Title
                });

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.CourseRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Course> records, int total, int totalDisplay)> GetCourseAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var list = await _unitOfWork.CourseRepository.GetDynamicAsync(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Title.Contains(searchText),
                sortText, null, pageIndex, pageSize);

            var result = (from datalist in list.data
                          select new Course()
                          {
                              Title = datalist.Title,
                              Fee = datalist.Fee,
                              SeatCount = datalist.SeatCount,
                              Id = datalist.Id,
                          }).ToList();

            return (result, list.total, list.totalDisplay);
        }

        public async Task<Course> LoadDataAsync(int id)
        {
            var entity = await _unitOfWork.CourseRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Course Id doesn't exist");

            return new Course
            {
                Title = entity.Title,
                Fee = entity.Fee,
                SeatCount = entity.SeatCount,
                Id = entity.Id
            };
        }

        public async Task UpdateAsync(Course courseData)
        {
            var entity = await _unitOfWork.CourseRepository.GetByIdAsync(courseData.Id);

            if (entity != null)
            {
                entity.Title = courseData.Title;
                entity.Fee = courseData.Fee;
                entity.SeatCount = courseData.SeatCount;

                await _unitOfWork.SaveAsync();
            }
            else
                throw new Exception("Id doesn't exist");
        }
    }
}