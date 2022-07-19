using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EReporteDAPs;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EReporteDAPProfile : Profile
    {
        public EReporteDAPProfile()
        {
            CreateMap<GetAllEReporteDAPsResponse, EReporteDAP>().ReverseMap();
        }

    }
}
