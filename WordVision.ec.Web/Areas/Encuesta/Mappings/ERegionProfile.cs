using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.ERegiones;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class ERegionProfile : Profile
    {
        public ERegionProfile()
        {
            CreateMap<GetAllERegionesResponse, ERegionViewModel>().ReverseMap();
            CreateMap<GetERegionesByIdResponse, ERegionViewModel>().ReverseMap();
            CreateMap<CreateERegionCommand, ERegionViewModel>().ReverseMap();
            CreateMap<UpdateERegionCommand, ERegionViewModel>().ReverseMap();
        }

    }
}
