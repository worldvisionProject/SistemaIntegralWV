using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Seguimientos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Seguimientos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class SeguimientoProfile : Profile
    {
        public SeguimientoProfile()
        {
            CreateMap<CreateSeguimientoCommand, Seguimiento>().ReverseMap();
            CreateMap<GetSeguimientoByIdResponse, Seguimiento>().ReverseMap();
      

        }
    }
}
