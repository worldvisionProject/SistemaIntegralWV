using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EEvaluaciones;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EEvaluacionProfile : Profile
    {
        public EEvaluacionProfile()
        {
            CreateMap<GetAllEEvaluacionesResponse, EEvaluacion>().ReverseMap();
            CreateMap<GetEEvaluacionesByIdResponse, EEvaluacion>().ReverseMap();
            CreateMap<CreateEEvaluacionCommand, EEvaluacion>().ReverseMap();
            CreateMap<UpdateEEvaluacionCommand, EEvaluacion>().ReverseMap();
        }

    }
}
