using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProvincias;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EProvinciaProfile : Profile
    {
        public EProvinciaProfile()
        {
            CreateMap<GetAllEProvinciasResponse, EProvincia>().ReverseMap();
            CreateMap<GetEProvinciasByIdResponse, EProvincia>().ReverseMap();
        }


    }
}
