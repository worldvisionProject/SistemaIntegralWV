using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EComunidades;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EComunidadProfile : Profile
    {
        public EComunidadProfile()
        {
            CreateMap<GetAllEComunidadesResponse, EComunidad>().ReverseMap();
            CreateMap<GetEComunidadesByIdResponse, EComunidad>().ReverseMap();
            CreateMap<CreateEComunidadCommand, EComunidad>().ReverseMap();
            CreateMap<UpdateEComunidadCommand, EComunidad>().ReverseMap();
        }

    }
}
