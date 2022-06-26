using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.ERegiones;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class ERegionProfile : Profile
    {
        public ERegionProfile()
        {
            CreateMap<GetAllERegionesResponse, ERegion>().ReverseMap();
            CreateMap<GetERegionesByIdResponse, ERegion>().ReverseMap();
            CreateMap<CreateERegionCommand, ERegion>().ReverseMap();
            CreateMap<UpdateERegionCommand, ERegion>().ReverseMap();
        }


    }
}
