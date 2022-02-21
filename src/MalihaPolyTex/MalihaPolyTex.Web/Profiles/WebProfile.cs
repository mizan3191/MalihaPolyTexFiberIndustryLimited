using AutoMapper;
using MalihaPolyTex.Institute.BusinessObjects;
using MalihaPolyTex.Web.Models;

namespace MalihaPolyTex.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Student, StudentCreateModel>().ReverseMap();
        }
    }
}