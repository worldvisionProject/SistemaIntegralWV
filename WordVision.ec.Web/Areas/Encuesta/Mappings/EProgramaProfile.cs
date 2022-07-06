using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProgramas;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EProgramaProfile : Profile
    {
        public EProgramaProfile()
        {
            CreateMap<GetAllEProgramasResponse, EProgramaViewModel>().ReverseMap();
            CreateMap<GetEProgramasByIdResponse, EProgramaViewModel>().ReverseMap();
            CreateMap<CreateEProgramaCommand, EProgramaViewModel>().ReverseMap();
            CreateMap<UpdateEProgramaCommand, EProgramaViewModel>().ReverseMap();
        }

    }
}
