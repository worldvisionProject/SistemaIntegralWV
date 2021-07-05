using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class EstrategiaNacionalProfile:Profile
    {
        public EstrategiaNacionalProfile()
        {
            CreateMap<GetAllEstrategiaNacionalesCachedResponse, EstrategiaNacionalViewModel>().ReverseMap();
            CreateMap<GetEstrategiaNacionalByIdResponse, EstrategiaNacionalViewModel>().ReverseMap();
            CreateMap<CreateEstrategiaNacionalCommand, EstrategiaNacionalViewModel>().ReverseMap();
            CreateMap<UpdateEstrategiaNacionalCommand, EstrategiaNacionalViewModel>().ReverseMap();
            CreateMap<GetAllEstrategiaNacionalesCachedResponse, EstrategiaNacionalList>().ReverseMap();
            CreateMap<EstrategiaNacional, EstrategiaNacionalViewModel>().ReverseMap();

        }
    }
}
