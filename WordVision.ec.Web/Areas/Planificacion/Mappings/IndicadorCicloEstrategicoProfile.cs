using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class IndicadorCicloEstrategicoProfile : Profile
    {
        public IndicadorCicloEstrategicoProfile()
        {
            CreateMap<CreateIndicadorCicloEstrategicoCommand, IndicadorCicloEstrategicoViewModel>().ReverseMap();
            CreateMap<UpdateIndicadorCicloEstrategicoCommand, IndicadorCicloEstrategicoViewModel>().ReverseMap();
            CreateMap<GetIndicadorCicloEstrategicoByIdResponse, IndicadorCicloEstrategicoViewModel>().ReverseMap();
            CreateMap<IndicadorCicloEstrategicoViewModel, IndicadorCicloEstrategico>().ReverseMap();
            CreateMap<IndicadorVinculadoCE, IndicadorVinculadoCEViewModel>().ReverseMap();

        }
    }
}
