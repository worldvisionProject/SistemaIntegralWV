using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class ActividadProfile : Profile
    {
        public ActividadProfile()
        {
            CreateMap<CreateActividadCommand, Actividad>().ReverseMap();
            CreateMap<GetActividadByIdResponse, Actividad>().ReverseMap();
            CreateMap<UpdateActividadCommand, Actividad>().ReverseMap();

        }
    }
}
