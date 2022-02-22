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
    public class CourseService : ICourseService
    {
        private IMalihaPolyTexUnitOfWork _unitOfWork;
        
        public CourseService(IMalihaPolyTexUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}