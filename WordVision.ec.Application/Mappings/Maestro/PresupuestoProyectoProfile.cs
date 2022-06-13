using AutoMapper;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Update;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class PresupuestoProyectoProfile : Profile
    {
        public PresupuestoProyectoProfile()
        {
            CreateMap<CreatePresupuestoProyectoCommand, PresupuestoProyecto>().ReverseMap();
            CreateMap<PresupuestoProyectoResponse, PresupuestoProyecto>().ReverseMap();
            CreateMap<UpdatePresupuestoProyectoCommand, PresupuestoProyecto>().ReverseMap();
            CreateMap<GetAllPresupuestoProyectoQuery, PresupuestoProyecto>().ReverseMap();
        }
       
    }
}
