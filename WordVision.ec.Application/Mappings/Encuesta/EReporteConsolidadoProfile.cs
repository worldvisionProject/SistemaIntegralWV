using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EReporteConsolidados;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EReporteConsolidadoProfile : Profile
    {
        public EReporteConsolidadoProfile()
        {
            CreateMap<GetAllEReporteConsolidadosResponse, EReporteConsolidado>().ReverseMap();
        }

    }
}
