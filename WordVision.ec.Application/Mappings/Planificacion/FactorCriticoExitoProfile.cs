using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class FactorCriticoExitoProfile : Profile
    {
        public FactorCriticoExitoProfile()
        {
            CreateMap<CreateFactorCriticoExitoCommand, FactorCriticoExito>().ReverseMap();
            CreateMap<GetFactorCriticoExitoByIdResponse, FactorCriticoExito>().ReverseMap();
            CreateMap<GetAllFactorCriticoExitoesCachedResponse, FactorCriticoExito>().ReverseMap();

        }
    }
}
