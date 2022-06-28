using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetAll;
using WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class TiposIndicadorProfile:Profile
    {
        public TiposIndicadorProfile()
        {

            CreateMap<GetTiposIndicadorByIdResponse, TiposIndicadorViewModel>().ReverseMap();

            CreateMap<GetAllTiposIndicadoresResponse, TiposIndicadorViewModel>().ReverseMap();
            CreateMap<TiposIndicadorViewModel, TiposIndicador>().ReverseMap();

        }
    }
}
