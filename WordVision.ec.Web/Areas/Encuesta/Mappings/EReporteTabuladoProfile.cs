using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EReporteTabulados;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EReporteTabuladoProfile : Profile
    {
        public EReporteTabuladoProfile()
        {
            //CreateMap<GetAllEReporteTabuladosResponse, EReporteTabuladoViewModel>().ReverseMap();

            CreateMap<GetAllEReporteTabuladosResponse, EReporteTabuladoViewModel>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.CodigoIndicador))
                .ForMember(dest => dest.PA, opt => opt.MapFrom(src => src.PA))
                .ForMember(dest => dest.Indicador, opt => opt.MapFrom(src => src.Indicador))
                .ForMember(dest => dest.NumeroTotal, opt => opt.MapFrom(src => src.NumeroTotal))
                .ForMember(dest => dest.EntrevistadosTotal, opt => opt.MapFrom(src => src.EntrevistadosTotal))
                .ForMember(dest => dest.Porcentaje, opt => opt.MapFrom(src => src.Porcentaje))
                .ForMember(dest => dest.Resultado, opt => opt.MapFrom(src => src.Result)).ReverseMap();

        }

    }
}
