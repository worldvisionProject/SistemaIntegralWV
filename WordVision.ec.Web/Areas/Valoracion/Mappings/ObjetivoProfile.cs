using AutoMapper;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached;
using WordVision.ec.Domain.Entities.Valoracion;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Mappings
{
    public class ObjetivoProfile:Profile
    {
        public ObjetivoProfile()
        {
            //CreateMap<GetObjetivoByIdResponse, ObjetivoViewModel>().ReverseMap();
            CreateMap<GetAllResultadosCachedResponse, ResultadoViewModel>().ReverseMap();
            CreateMap<Resultado, ResultadoViewModel>().ReverseMap();
            CreateMap<ObjetivoResponse, ObjetivoResponseViewModel>().ReverseMap();
            CreateMap<ObjetivoAnioFiscal, ObjetivoAnioFiscalViewModel>().ReverseMap();

            CreateMap<WordVision.ec.Application.DTOs.Valoracion.ObjetivoAnioFiscalResponse, WordVision.ec.Web.Areas.Valoracion.Models.ObjetivoAnioFiscalResponse>().ReverseMap();
            CreateMap<WordVision.ec.Application.DTOs.Valoracion.PlanificacionResultadoResponse, WordVision.ec.Web.Areas.Valoracion.Models.PlanificacionResultadoResponse>().ReverseMap();
            CreateMap<WordVision.ec.Application.DTOs.Valoracion.ResultadoResponse, WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached.GetAllResultadosCachedResponse>().ReverseMap();

            CreateMap<GetPlanificacionResultadoByIdResponse, PlanificacionResultadoViewModel>().ReverseMap();
            CreateMap<PlanificacionResultadoViewModel, PlanificacionResultado>().ReverseMap();

            CreateMap<CreatePlanificacionResultadoCommand, PlanificacionResultadoViewModel>().ReverseMap();
            CreateMap<UpdatePlanificacionResultadoCommand, PlanificacionResultadoViewModel>().ReverseMap();

            CreateMap<GetObjetivoPonderacionResponse, ObjetivoAnioFiscalViewModel>().ReverseMap();
            CreateMap<PlanificacionHito, PlanificacionHitoViewModel>().ReverseMap();
        }
    }
}
