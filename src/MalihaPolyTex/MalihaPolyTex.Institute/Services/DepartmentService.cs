using AutoMapper;
using MalihaPolyTex.Institute.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalihaPolyTex.Institute.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IMalihaPolyTexUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IMalihaPolyTexUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
