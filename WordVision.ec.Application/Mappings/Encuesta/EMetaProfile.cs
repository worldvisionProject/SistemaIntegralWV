using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EMetas;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EMetaProfile : Profile
    {
        public EMetaProfile()
        {
            CreateMap<GetAllEMetasResponse, EMeta>().ReverseMap();
            CreateMap<GetEMetasByIdResponse, EMeta>().ReverseMap();
            CreateMap<CreateEMetaCommand, EMeta>().ReverseMap();
            CreateMap<UpdateEMetaCommand, EMeta>().ReverseMap();
        }




    }
}
