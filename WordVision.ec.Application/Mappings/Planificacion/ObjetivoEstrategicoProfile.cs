using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class ObjetivoEstrategicoProfile : Profile
    {
        public ObjetivoEstrategicoProfile()
        {
            CreateMap<CreateObjetivoEstrategicoCommand, ObjetivoEstrategico>().ReverseMap();
            CreateMap<GetObjetivoEstrategicoByIdResponse, ObjetivoEstrategico>().ReverseMap();
            CreateMap<GetAllObjetivoEstrategicoesCachedResponse, ObjetivoEstrategico>().ReverseMap();

        }
    }
}
