using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EIndicadores;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EIndicadorProfile : Profile
    {
        public EIndicadorProfile()
        {
            CreateMap<GetAllEIndicadoresResponse, EIndicadorViewModel>().ReverseMap();
            CreateMap<GetEIndicadoresByIdResponse, EIndicadorViewModel>().ReverseMap();
            CreateMap<CreateEIndicadorCommand, EIndicadorViewModel>().ReverseMap();
            CreateMap<UpdateEIndicadorCommand, EIndicadorViewModel>().ReverseMap();
        }

    }
}
