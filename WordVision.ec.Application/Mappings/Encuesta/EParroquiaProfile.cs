using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EParroquias;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EParroquiaProfile : Profile
    {
        public EParroquiaProfile()
        {
            CreateMap<GetAllEParroquiasResponse, EParroquia>().ReverseMap();
            CreateMap<GetEParroquiasByIdResponse, EParroquia>().ReverseMap();
            CreateMap<CreateEParroquiaCommand, EParroquia>().ReverseMap();
            CreateMap<UpdateEParroquiaCommand, EParroquia>().ReverseMap();
        }

    }
}
