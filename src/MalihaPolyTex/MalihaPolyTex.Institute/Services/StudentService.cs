using AutoMapper;
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
        private readonly IMapper _mapper;

        public StudentService(IMalihaPolyTexUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}