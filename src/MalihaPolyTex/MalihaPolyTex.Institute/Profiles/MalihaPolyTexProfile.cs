using AutoMapper;
using EO = MalihaPolyTex.Institute.Entities;
using BO = MalihaPolyTex.Institute.BusinessObjects;

namespace MalihaPolyTex.Institute.Profiles
{
    public class MalihaPolyTexProfile : Profile
    {
        public MalihaPolyTexProfile()
        {
            CreateMap<BO.Student, EO.Student>().ReverseMap();
        }
    }
}