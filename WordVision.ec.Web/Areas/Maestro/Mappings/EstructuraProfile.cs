

using AutoMapper;
using WordVision.ec.Application.Features.Maestro.Estructuras.Commands.Create;
using WordVision.ec.Application.Features.Maestro.Estructuras.Commands.Update;
using WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetAllCached;
using WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetById;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class EstructuraProfile : Profile
    {
        public EstructuraProfile()
        {
             CreateMap<GetAllEstructurasCachedResponse, EstructuraViewModel>().ReverseMap();
            CreateMap<GetEstructuraByIdResponse, EstructuraViewModel>().ReverseMap();
            CreateMap<CreateEstructuraCommand, EstructuraViewModel>().ReverseMap();
            CreateMap<UpdateEstructuraCommand, EstructuraViewModel>().ReverseMap();
        }
    }
}
