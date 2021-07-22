using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Create;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class IndicadorPOAProfile: Profile
    {
        public IndicadorPOAProfile()
        {
            CreateMap<CreateIndicadorPOACommand, IndicadorPOA>().ReverseMap();
            CreateMap<GetIndicadorPOAByIdResponse, IndicadorPOA>().ReverseMap();
            CreateMap<GetAllIndicadorPOAsCachedResponse, IndicadorPOA>().ReverseMap();

        }
    }
}
