using AutoMapper;
using WordVision.ec.Application.Features.Presupuesto.Presupuesto.Commands.Create;
using WordVision.ec.Application.Features.Presupuesto.Presupuesto.Queries.GetAllCached;
namespace WordVision.ec.Application.Mappings.Presupuesto
{
    internal class PresupuestoProfile : Profile
    {
        public PresupuestoProfile()
        {
            CreateMap<CreatePresupuestoCommand, WordVision.ec.Domain.Entities.Presupuesto.Presupuesto>().ReverseMap();
            CreateMap<GetAllPresupuestosCachedResponse, Domain.Entities.Presupuesto.Presupuesto>().ReverseMap();
        }
    }
}
