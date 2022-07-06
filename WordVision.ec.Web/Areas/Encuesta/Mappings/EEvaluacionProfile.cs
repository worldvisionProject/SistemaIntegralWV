using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EEvaluaciones;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EEvaluacionProfile : Profile
    {
        public EEvaluacionProfile()
        {
            CreateMap<GetAllEEvaluacionesResponse, EEvaluacionViewModel>().ReverseMap();
            CreateMap<GetEEvaluacionesByIdResponse, EEvaluacionViewModel>().ReverseMap();
            CreateMap<CreateEEvaluacionCommand, EEvaluacionViewModel>().ReverseMap();
            CreateMap<UpdateEEvaluacionCommand, EEvaluacionViewModel>().ReverseMap();
        }

    }
}
