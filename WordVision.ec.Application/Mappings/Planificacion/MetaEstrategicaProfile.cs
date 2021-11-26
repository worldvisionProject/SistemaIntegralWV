using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class MetaEstrategicaProfile : Profile
    {
        public MetaEstrategicaProfile()
        {
            CreateMap<CreateMetaEstrategicaCommand, IndicadorEstrategico>().ReverseMap();
            CreateMap<GetMetaEstrategicaByIdResponse, IndicadorEstrategico>().ReverseMap();
            CreateMap<UpdateMetaEstrategicaCommand, IndicadorEstrategico>().ReverseMap();

        }
    }
}
