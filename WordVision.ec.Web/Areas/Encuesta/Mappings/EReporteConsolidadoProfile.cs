using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EReporteConsolidados;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EReporteConsolidadoProfile : Profile
    {

        public EReporteConsolidadoProfile()
        {
            CreateMap<GetAllEReporteConsolidadosResponse, EReporteConsolidadoViewModel>().ReverseMap();

        }

    }
}
