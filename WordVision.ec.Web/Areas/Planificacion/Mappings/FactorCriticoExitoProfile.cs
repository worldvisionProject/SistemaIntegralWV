using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class FactorCriticoExitoProfile:Profile
    {
        public FactorCriticoExitoProfile()
        {
            CreateMap<GetAllFactorCriticoExitoesCachedResponse, FactorCriticoExitoViewModel>().ReverseMap();
            CreateMap<GetFactorCriticoExitoByIdResponse, FactorCriticoExitoViewModel>().ReverseMap();
            CreateMap<CreateFactorCriticoExitoCommand, FactorCriticoExitoViewModel>().ReverseMap();
            CreateMap<UpdateFactorCriticoExitoCommand, FactorCriticoExitoViewModel>().ReverseMap();
            CreateMap<FactorCriticoExito, FactorCriticoExitoViewModel>().ReverseMap();
        }
    }
}
