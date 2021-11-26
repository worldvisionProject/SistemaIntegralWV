

using AutoMapper;
using WordVision.ec.Application.Features.Maestro.Estructuras.Commands.Create;
using WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetAllCached;
using WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetById;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class EstructuraProfile : Profile
    {
        public EstructuraProfile()
        {
            CreateMap<CreateEstructuraCommand, Estructura>().ReverseMap();
            CreateMap<GetEstructuraByIdResponse, Estructura>().ReverseMap();
            CreateMap<GetAllEstructurasCachedResponse, Estructura>().ReverseMap();

        }
    }
}
