using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class IndicadorEstrategicoProfile : Profile
    {
        public IndicadorEstrategicoProfile()
        {
            CreateMap<CreateIndicadorEstrategicoCommand, IndicadorEstrategico>().ReverseMap();
            CreateMap<GetIndicadorEstrategicoByIdResponse, IndicadorEstrategico>().ReverseMap();
            CreateMap<GetAllIndicadorEstrategicoesCachedResponse, IndicadorEstrategico>().ReverseMap();

        }
    }
}
