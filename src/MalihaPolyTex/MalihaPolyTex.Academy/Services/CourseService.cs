using MalihaPolyTex.Academy.BusinessObjects;
using MalihaPolyTex.Academy.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MalihaPolyTex.Academy.Services
{
    public class CourseService : ICourseService
    {
        private readonly IAcademyUnitOfWork _unitOfWork;
        public CourseService(IAcademyUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCourseAsync(Course course)
        {
            await _unitOfWork.CourseRepository.AddAsync(
                new Entities.Course()
                {
                    Title = course.Title,
                    Fee = course.Fee,
                    SeatCount = course.SeatCount
                });
            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Course> records, int total, int totalDisplay)> CreateCourseAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var courseData = await _unitOfWork.CourseRepository.GetDynamicAsync(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Title.Contains(searchText),
                sortText, null, pageIndex, pageSize);

            var resultData = (from course in courseData.data
                              select new Course
                              {
                                  Title = course.Title,
                                  Fee = course.Fee,
                                  SeatCount = course.SeatCount,
                                  Id = course.Id
                              }).ToList();

            return(resultData, courseData.total, courseData.totalDisplay);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _unitOfWork.CourseRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<Course> LoadCourseDataAsync(int id)
        {
            var courseEntity = await _unitOfWork.CourseRepository.GetByIdAsync(id);

            if (courseEntity == null) return null;

            return new Course()
            {
                Id = courseEntity.Id,
                Title = courseEntity.Title,
                Fee = courseEntity.Fee,
                SeatCount = courseEntity.SeatCount
            };
        }

        public async Task<IList<Course>> LoadCourseDataAsync()
        {
            var courseEntity = await _unitOfWork.CourseRepository.GetAllAsync();
            var courses = new List<Course>();
            foreach(var entity in courseEntity)
            {
                var course = new Course()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Fee = entity.Fee,
                    SeatCount = entity.SeatCount
                };
                courses.Add(course);
            }

            return courses;
        }

        public async Task UpdateCourseAsync(Course course)
        {
            if (course == null)
                throw new InvalidOperationException("Department missing");

            var courseEntity = await _unitOfWork.CourseRepository.GetByIdAsync(course.Id);

            if (courseEntity != null)
            {
                courseEntity.Id = course.Id;
                courseEntity.Title = course.Title;
                courseEntity.Fee = course.Fee;
                courseEntity.SeatCount = course.SeatCount;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}