using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Seguimientos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Seguimientos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class SeguimientoProfile : Profile
    {
        public SeguimientoProfile()
        {
            CreateMap<CreateSeguimientoCommand, SeguimientoViewModel>().ReverseMap();
            CreateMap<GetSeguimientoByIdResponse, SeguimientoViewModel>().ReverseMap();
            CreateMap<Seguimiento, SeguimientoViewModel>().ReverseMap();

        }
    }
}
