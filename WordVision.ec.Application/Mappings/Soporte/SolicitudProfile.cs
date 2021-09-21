using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Mappings.Soporte
{
    public class SolicitudProfile : Profile
    {
        public SolicitudProfile()
        {
            CreateMap<CreateSolicitudCommand, Solicitud>().ReverseMap();
            CreateMap<GetSolicitudByIdResponse, Solicitud>().ReverseMap();
            CreateMap<UpdateSolicitudCommand, Solicitud>().ReverseMap();

        }
    }
}
