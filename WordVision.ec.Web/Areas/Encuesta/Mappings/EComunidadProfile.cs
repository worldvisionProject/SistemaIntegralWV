using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.EComunidades;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class EComunidadProfile : Profile
    {
        public EComunidadProfile()
        {
            CreateMap<GetAllEComunidadesResponse, EComunidadViewModel>().ReverseMap();
            CreateMap<GetEComunidadesByIdResponse, EComunidadViewModel>().ReverseMap();
            CreateMap<CreateEComunidadCommand, EComunidadViewModel>().ReverseMap();
            CreateMap<UpdateEComunidadCommand, EComunidadViewModel>().ReverseMap();
        }
    }
}
