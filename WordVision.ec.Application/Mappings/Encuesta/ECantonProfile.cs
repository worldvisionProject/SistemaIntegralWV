using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.ECantones;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class ECantonProfile : Profile
    {
        public ECantonProfile()
        {
            CreateMap<GetAllECantonesResponse, ECanton>().ReverseMap();
            CreateMap<GetECantonesByIdResponse, ECanton>().ReverseMap();
            CreateMap<CreateECantonCommand, ECanton>().ReverseMap();
            CreateMap<UpdateECantonCommand, ECanton>().ReverseMap();
        }


    }
}
