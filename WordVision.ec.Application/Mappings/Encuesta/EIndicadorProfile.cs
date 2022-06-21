using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EIndicadores;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EIndicadorProfile : Profile
    {
        public EIndicadorProfile()
        {
            CreateMap<GetAllEIndicadoresResponse, EIndicador>().ReverseMap();
            CreateMap<GetEIndicadoresByIdResponse, EIndicador>().ReverseMap();
        }



    }
}
