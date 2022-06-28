using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;

using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Mappings.Valoracion
{
    public class ObjetivoProfile : Profile
    {
        public ObjetivoProfile()
        {
            CreateMap<GetObjetivoPonderacionResponse, ObjetivoAnioFiscal>().ReverseMap();
            CreateMap<GetObjetivoByIdResponse, Objetivo>().ReverseMap();
        }
    }
}
