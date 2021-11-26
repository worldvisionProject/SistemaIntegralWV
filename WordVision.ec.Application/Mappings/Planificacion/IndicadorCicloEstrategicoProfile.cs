using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    internal class IndicadorCicloEstrategicoProfile : Profile
    {
        public IndicadorCicloEstrategicoProfile()
        {
            CreateMap<CreateIndicadorCicloEstrategicoCommand, IndicadorCicloEstrategico>().ReverseMap();
            CreateMap<GetIndicadorCicloEstrategicoByIdResponse, IndicadorCicloEstrategico>().ReverseMap();

        }
    }
}
