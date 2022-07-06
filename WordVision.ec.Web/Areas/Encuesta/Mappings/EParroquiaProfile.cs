using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EParroquias;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EParroquiaProfile : Profile
    {
        public EParroquiaProfile()
        {
            CreateMap<GetAllEParroquiasResponse, EParroquiaViewModel>().ReverseMap();
            CreateMap<GetEParroquiasByIdResponse, EParroquiaViewModel>().ReverseMap();
            CreateMap<CreateEParroquiaCommand, EParroquiaViewModel>().ReverseMap();
            CreateMap<UpdateEParroquiaCommand, EParroquiaViewModel>().ReverseMap();
        }
    }
}
