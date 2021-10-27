using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Create;
using WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Update;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class CatalogoProfile : Profile
    {
        public CatalogoProfile()
        {
            CreateMap<GetAllCatalogosCachedResponse, CatalogoViewModel>().ReverseMap();
            CreateMap<GetCatalogoByIdResponse, CatalogoViewModel>().ReverseMap();
            CreateMap<CreateCatalogoCommand, CatalogoViewModel>().ReverseMap();
            CreateMap<UpdateCatalogoCommand, CatalogoViewModel>().ReverseMap();
            CreateMap<DetalleCatalogoViewModel, DetalleCatalogo>().ReverseMap();


        }
    }
}
