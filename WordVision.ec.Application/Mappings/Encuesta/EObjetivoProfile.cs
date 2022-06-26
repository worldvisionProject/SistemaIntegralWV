using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EIndicadores;
using WordVision.ec.Application.Features.Encuesta.EObjetivos;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EObjetivoProfile : Profile
    {
        public EObjetivoProfile()
        {
            CreateMap<GetAllEObjetivosResponse, EObjetivo>().ReverseMap();
            CreateMap<GetEObjetivosByIdResponse, EObjetivo>().ReverseMap();
            CreateMap<CreateEObjetivoCommand, EObjetivo>().ReverseMap();
            CreateMap<UpdateEObjetivoCommand, EObjetivo>().ReverseMap();
        }



    }
}
