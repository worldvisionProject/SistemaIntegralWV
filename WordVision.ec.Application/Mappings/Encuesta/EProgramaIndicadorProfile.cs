using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EProgramaIndicadorProfile : Profile
    {
        public EProgramaIndicadorProfile()
        {
            CreateMap<GetAllEProgramaIndicadoresResponse, EProgramaIndicador>().ReverseMap();
            CreateMap<GetEProgramaIndicadoresByIdResponse, EProgramaIndicador>().ReverseMap();
            CreateMap<CreateEProgramaIndicadorCommand, EProgramaIndicador>().ReverseMap();
            CreateMap<UpdateEProgramaIndicadorCommand, EProgramaIndicador>().ReverseMap();
        }




    }
}
