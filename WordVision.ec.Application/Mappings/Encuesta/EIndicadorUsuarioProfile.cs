using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EIndicadorUsuarios;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EIndicadorUsuarioProfile : Profile
    {
        public EIndicadorUsuarioProfile()
        {
            CreateMap<GetAllEIndicadorUsuariosResponse, EIndicadorUsuario>().ReverseMap();
            CreateMap<GetEIndicadorUsuariosByIdResponse, EIndicadorUsuario>().ReverseMap();
        }




    }
}
