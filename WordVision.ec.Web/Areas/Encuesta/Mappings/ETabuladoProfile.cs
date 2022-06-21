using AutoMapper;
using WordVision.ec.Application.Features.Encuesta.ETabulados;
using WordVision.ec.Domain.Entities.Encuesta;
using WordVision.ec.Web.Areas.Encuesta.Models;

namespace WordVision.ec.Web.Areas.Encuesta.Mappings
{
    public class ETabuladoProfile : Profile
    {
        public ETabuladoProfile()
        {
            CreateMap<GetAllETabuladosResponse, ETabuladoViewModel>().ReverseMap();

            CreateMap<ETabulado, ETabuladoViewModel>().ReverseMap();
        }

    }
}
