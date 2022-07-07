using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.ECantones;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class ECantonProfile : Profile
    {
        public ECantonProfile()
        {
            CreateMap<GetAllECantonesResponse, ECantonViewModel>().ReverseMap();
            CreateMap<GetECantonesByIdResponse, ECantonViewModel>().ReverseMap();
            CreateMap<CreateECantonCommand, ECantonViewModel>().ReverseMap();
            CreateMap<UpdateECantonCommand, ECantonViewModel>().ReverseMap();
        }
    }
}
