using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EncuestaKobos;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EncuestaKoboProfile : Profile
    {
        public EncuestaKoboProfile()
        {
            CreateMap<CreateEncuestaKoboCommand, EncuestaKoboViewModel>().ReverseMap();
            CreateMap<UpdateEncuestaKoboCommand, EncuestaKoboViewModel>().ReverseMap();

            CreateMap<GetAllEncuestaKobosResponse, EncuestaKoboViewModel>().ReverseMap();
            CreateMap<GetEncuestaKobosByIdResponse, EncuestaKoboViewModel>().ReverseMap();
            CreateMap<GetAllEncuestaKobosFromAPIResponse, EncuestaKoboViewModel>().ReverseMap();

            CreateMap<EncuestaKobo, GetEncuestaKobosByIdResponse>().ReverseMap();
            CreateMap<EncuestaKobo, EncuestaKoboViewModel>().ReverseMap();
        }

    }
}
