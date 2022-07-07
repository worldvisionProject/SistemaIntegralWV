using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EProyectos;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EProyectoProfile : Profile
    {
        public EProyectoProfile()
        {
            CreateMap<GetAllEProyectosResponse, EProyectoViewModel>().ReverseMap();
            CreateMap<GetEProyectosByIdResponse, EProyectoViewModel>().ReverseMap();
            CreateMap<CreateEProyectoCommand, EProyectoViewModel>().ReverseMap();
            CreateMap<UpdateEProyectoCommand, EProyectoViewModel>().ReverseMap();
        }

    }
}
