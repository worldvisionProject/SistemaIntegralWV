using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById;
using WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class IndicadorProductoObjetivoProfile : Profile
    {
        public IndicadorProductoObjetivoProfile()
        {
            CreateMap<CreateIndicadorProductoObjetivoCommand, IndicadorProductoObjetivoViewModel>().ReverseMap();
            CreateMap<UpdateIndicadorProductoObjetivoCommand, IndicadorProductoObjetivoViewModel>().ReverseMap();
            CreateMap<GetIndicadorProductoObjetivoByIdResponse, IndicadorProductoObjetivoViewModel>().ReverseMap();
            CreateMap<IndicadorProductoObjetivo, IndicadorProductoObjetivoViewModel>().ReverseMap();

        }
    }
}
