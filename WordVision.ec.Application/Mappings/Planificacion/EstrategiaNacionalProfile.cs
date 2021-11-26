using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    internal class EstrategiaNacionalProfile : Profile
    {
        public EstrategiaNacionalProfile()
        {
            CreateMap<CreateEstrategiaNacionalCommand, EstrategiaNacional>().ReverseMap();
            CreateMap<GetEstrategiaNacionalByIdResponse, EstrategiaNacional>().ReverseMap();
            CreateMap<GetAllEstrategiaNacionalesCachedResponse, EstrategiaNacional>().ReverseMap();

        }
    }
}
