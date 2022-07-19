using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EReporteDAPs;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EReporteDAPProfile : Profile
    {

        public EReporteDAPProfile()
        {
            CreateMap<GetAllEReporteDAPsResponse, EReporteDAPViewModel>().ReverseMap();

        }

    }
}
