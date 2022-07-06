using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EObjetivos;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EObjetivoProfile : Profile
    {
        public EObjetivoProfile()
        {
            CreateMap<GetAllEObjetivosResponse, EObjetivoViewModel>().ReverseMap();
            CreateMap<GetEObjetivosByIdResponse, EObjetivoViewModel>().ReverseMap();
            CreateMap<CreateEObjetivoCommand, EObjetivoViewModel>().ReverseMap();
            CreateMap<UpdateEObjetivoCommand, EObjetivoViewModel>().ReverseMap();
        }

    }
}
