using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class ActividadProfile : Profile
    {
        public ActividadProfile()
        {
            CreateMap<CreateActividadCommand, ActividadViewModel>().ReverseMap();
            CreateMap<GetActividadByIdResponse, ActividadViewModel>().ReverseMap();
            CreateMap<UpdateActividadCommand, ActividadViewModel>().ReverseMap();

        }
    }
}
