using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProvincias;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EProvinciaProfile : Profile
    {
        public EProvinciaProfile()
        {
            CreateMap<GetAllEProvinciasResponse, EProvinciaViewModel>().ReverseMap();
            CreateMap<GetEProvinciasByIdResponse, EProvinciaViewModel>().ReverseMap();
            CreateMap<CreateEProvinciaCommand, EProvinciaViewModel>().ReverseMap();
            CreateMap<UpdateEProvinciaCommand, EProvinciaViewModel>().ReverseMap();
        }

    }
}
