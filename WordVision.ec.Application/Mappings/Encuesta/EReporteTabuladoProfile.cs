using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EReporteTabulados;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EReporteTabuladoProfile : Profile
    {
        public EReporteTabuladoProfile()
        {
            //CreateMap<GetAllEReporteTabuladosResponse, EReporteTabulado>().ReverseMap();

            CreateMap<GetAllEReporteTabuladosResponse, EReporteTabulado>()
                .ForPath(dest => dest.EIndicador.Id, opt => opt.MapFrom(src => src.CodigoIndicador))
                .ForPath(dest => dest.EPrograma.Id, opt => opt.MapFrom(src => src.CodigoPA))
                .ForMember(dest => dest.rta_nombre_pa, opt => opt.MapFrom(src => src.PA))
                .ForMember(dest => dest.rta_nombre_indicador, opt => opt.MapFrom(src => src.Indicador))
                .ForMember(dest => dest.rta_tipo_indicador, opt => opt.MapFrom(src => src.TipoIndicador))
                .ForMember(dest => dest.rta_numerador, opt => opt.MapFrom(src => src.NumeroTotal))
                .ForMember(dest => dest.rta_denominador, opt => opt.MapFrom(src => src.EntrevistadosTotal))
                .ForMember(dest => dest.rta_porcentaje, opt => opt.MapFrom(src => src.Porcentaje))
                .ForMember(dest => dest.rta_resultado, opt => opt.MapFrom(src => src.Result))
                .ForPath(dest => dest.ERegion.Id, opt => opt.MapFrom(src => src.CodigoRegion))
                .ForPath(dest => dest.EProvincia.Id, opt => opt.MapFrom(src => src.CodigoProvincia))
                .ForPath(dest => dest.ECanton.Id, opt => opt.MapFrom(src => src.CodigoCanton)).ReverseMap();

        }

    }
}
