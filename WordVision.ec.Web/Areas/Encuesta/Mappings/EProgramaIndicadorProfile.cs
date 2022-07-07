using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EProgramaIndicadorProfile : Profile
    {
        public EProgramaIndicadorProfile()
        {
            CreateMap<GetAllEProgramaIndicadoresResponse, EProgramaIndicadorViewModel>().ReverseMap();
            CreateMap<GetEProgramaIndicadoresByIdResponse, EProgramaIndicadorViewModel>().ReverseMap();
            CreateMap<CreateEProgramaIndicadorCommand, EProgramaIndicadorViewModel>().ReverseMap();
            CreateMap<UpdateEProgramaIndicadorCommand, EProgramaIndicadorViewModel>().ReverseMap();
        }

    }
}