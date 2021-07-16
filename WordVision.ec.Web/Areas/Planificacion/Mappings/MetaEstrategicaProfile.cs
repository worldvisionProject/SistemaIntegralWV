using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class MetaEstrategicaProfile : Profile
    {
        public MetaEstrategicaProfile()
        {
            CreateMap<CreateMetaEstrategicaCommand, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<GetMetaEstrategicaByIdResponse, IndicadorEstrategicoViewModel>().ReverseMap();
            CreateMap<MetaEstrategica, MetaViewModel>().ReverseMap();
            CreateMap<UpdateMetaEstrategicaCommand, IndicadorEstrategicoViewModel>().ReverseMap();

        }
    }
}
