﻿using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class IndicadorEstrategicoProfile : Profile
    {
        public IndicadorEstrategicoProfile()
        {
            CreateMap<GetAllIndicadorEstrategicoesCachedResponse, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<GetIndicadorEstrategicoByIdResponse, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<CreateIndicadorEstrategicoCommand, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<UpdateIndicadorEstrategicoCommand, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<IndicadorEstrategico, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<IndicadorAF, IndicadorAFViewModel>().ReverseMap();
            CreateMap<IndicadorVinculadoE, IndicadorVinculadoEViewModel>().ReverseMap();
        }
    }
}
