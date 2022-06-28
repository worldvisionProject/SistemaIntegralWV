using AutoMapper;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Create;
using WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class PresupuestoProyectoProfile : Profile
    {
        public PresupuestoProyectoProfile()
        {            
            CreateMap<PresupuestoProyectoResponse, PresupuestoProyectoViewModel>().ReverseMap();
            CreateMap<CreatePresupuestoProyectoCommand, PresupuestoProyectoViewModel>().ReverseMap();
            CreateMap<UpdatePresupuestoProyectoCommand, PresupuestoProyectoViewModel>().ReverseMap();
        }
        
    }
}
