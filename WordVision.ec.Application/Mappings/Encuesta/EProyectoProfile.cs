using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProyectos;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Mappings.Encuesta
{
    public class EProyectoProfile : Profile
    {
        public EProyectoProfile()
        {
            CreateMap<GetAllEProyectosResponse, EProyecto>().ReverseMap();
            CreateMap<GetEProyectosByIdResponse, EProyecto>().ReverseMap();
            CreateMap<CreateEProyectoCommand, EProyecto>().ReverseMap();
            CreateMap<UpdateEProyectoCommand, EProyecto>().ReverseMap();
        }

    }
}
