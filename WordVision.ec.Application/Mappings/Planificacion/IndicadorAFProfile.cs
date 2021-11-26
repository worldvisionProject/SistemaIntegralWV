using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class IndicadorAFProfile : Profile
    {
        public IndicadorAFProfile()
        {
            CreateMap<CreateIndicadorAFCommand, IndicadorAF>().ReverseMap();
            CreateMap<GetIndicadorAFByIdResponse, IndicadorAF>().ReverseMap();
            CreateMap<GetAllIndicadorAFesCachedResponse, IndicadorAF>().ReverseMap();

        }
    }
}
