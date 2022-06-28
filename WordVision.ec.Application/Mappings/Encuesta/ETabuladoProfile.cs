using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.ETabulados;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class ETabuladoProfile : Profile
    {
        public ETabuladoProfile()
        {
            CreateMap<GetAllETabuladosResponse, ETabulado>().ReverseMap();

        }

    }
}
