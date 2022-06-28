using AutoMapper;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById;
using WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetById;
using WordVision.ec.Domain.Entities.Valoracion;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Mappings
{
    public class ResponsabilidadProfile : Profile
    {
        public ResponsabilidadProfile()
        {
            CreateMap<ResponsabilidadResponse, ResponsabilidadViewModel>().ReverseMap();
            CreateMap<GetResponsabilidadByIdResponse, ResponsabilidadViewModel>().ReverseMap();
            CreateMap<ResponsabilidadViewModel, Responsabilidad>().ReverseMap();
            CreateMap<GetResultadoByIdResponse, ResultadoViewModel>().ReverseMap();
        }
    }
}
