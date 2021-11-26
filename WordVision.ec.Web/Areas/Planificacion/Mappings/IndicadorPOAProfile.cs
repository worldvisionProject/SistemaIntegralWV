using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Update;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    public class IndicadorPOAProfile : Profile
    {
        public IndicadorPOAProfile()
        {
            CreateMap<CreateIndicadorPOACommand, IndicadorPOAViewModel>().ReverseMap();
            CreateMap<GetIndicadorPOAByIdResponse, IndicadorPOAViewModel>().ReverseMap();
            CreateMap<GetAllIndicadorPOAsCachedResponse, IndicadorPOAViewModel>().ReverseMap();
            CreateMap<IndicadorPOA, IndicadorPOAViewModel>().ReverseMap();
            CreateMap<UpdateIndicadorPOACommand, IndicadorPOAViewModel>().ReverseMap();
            CreateMap<MetaViewModel, MetaTactica>().ReverseMap();
            CreateMap<ActividadViewModel, Actividad>().ReverseMap();


        }
    }
}
