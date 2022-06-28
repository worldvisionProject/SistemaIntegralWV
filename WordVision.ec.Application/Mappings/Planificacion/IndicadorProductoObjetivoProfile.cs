using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    internal class IndicadorProductoObjetivoProfile:Profile
    {
        public IndicadorProductoObjetivoProfile()
        {
            CreateMap<CreateIndicadorProductoObjetivoCommand, IndicadorProductoObjetivo>().ReverseMap();
            CreateMap<GetIndicadorProductoObjetivoByIdResponse, IndicadorProductoObjetivo>().ReverseMap();
            CreateMap<GetAllIndicadorProductoObjetivosCachedResponse, IndicadorProductoObjetivo>().ReverseMap();
        }
    }
}
