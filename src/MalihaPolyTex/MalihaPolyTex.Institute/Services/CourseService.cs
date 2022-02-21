using AutoMapper;
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
        private readonly IMapper _mapper;

        public CourseService(IMalihaPolyTexUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}