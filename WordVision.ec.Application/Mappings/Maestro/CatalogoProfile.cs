using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Create;
using WordVision.ec.Application.Features.Maestro.Catalogos.Commands.Update;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class CatalogoProfile : Profile
    {
        public CatalogoProfile()
        {
            CreateMap<CreateCatalogoCommand, Catalogo>().ReverseMap();
            CreateMap<GetCatalogoByIdResponse, Catalogo>().ReverseMap();
            CreateMap<GetAllCatalogosCachedResponse, Catalogo>().ReverseMap();
            CreateMap<UpdateCatalogoCommand, Catalogo>().ReverseMap();
     
            CreateMap<GetListByIdDetalleResponse, DetalleCatalogo>().ReverseMap();

        }
    }
}
