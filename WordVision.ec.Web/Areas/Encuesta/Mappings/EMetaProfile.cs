using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EMetas;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EMetaProfile : Profile
    {
        public EMetaProfile()
        {
            CreateMap<GetAllEMetasResponse, EMetaViewModel>().ReverseMap();
            CreateMap<GetEMetasByIdResponse, EMetaViewModel>().ReverseMap();
            CreateMap<CreateEMetaCommand, EMetaViewModel>().ReverseMap();
            CreateMap<UpdateEMetaCommand, EMetaViewModel>().ReverseMap();
        }

    }
}