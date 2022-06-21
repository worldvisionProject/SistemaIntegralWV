using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EncuestaKobos;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EncuestaKoboProfile : Profile
    {
        public EncuestaKoboProfile()
        {
            CreateMap<CreateEncuestaKoboCommand, EncuestaKobo>().ReverseMap();
            CreateMap<UpdateEncuestaKoboCommand, EncuestaKobo>().ReverseMap();

            CreateMap<GetAllEncuestaKobosResponse, EncuestaKobo>().ReverseMap();
            CreateMap<GetEncuestaKobosByIdResponse, EncuestaKobo>().ReverseMap();
            CreateMap<GetAllEncuestaKobosFromAPIResponse, EncuestaKobo>().ReverseMap();

        }

    }
}
