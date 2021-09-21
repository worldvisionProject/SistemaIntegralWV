using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Domain.Entities.Soporte;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Mappings
{
    public class SolicitudProfile : Profile
    {
        public SolicitudProfile()
        {
            CreateMap<CreateSolicitudCommand, SolicitudViewModel>().ReverseMap();
            CreateMap<GetSolicitudByIdResponse, SolicitudViewModel>().ReverseMap();
            CreateMap<UpdateSolicitudCommand, SolicitudViewModel>().ReverseMap();
            CreateMap<Solicitud, SolicitudViewModel>().ReverseMap();
        }
    }
}
