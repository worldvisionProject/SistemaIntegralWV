using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Mappings.Valoracion
{
    public class PlanificacionResultadoProfile : Profile
    {
        public PlanificacionResultadoProfile()
        {
            CreateMap<CreatePlanificacionResultadoCommand, PlanificacionResultado>().ReverseMap();
            CreateMap<UpdatePlanificacionResultadoCommand, PlanificacionResultado>().ReverseMap();
            CreateMap<GetPlanificacionResultadoByIdResponse, PlanificacionResultado>().ReverseMap();


        }
    }
}
