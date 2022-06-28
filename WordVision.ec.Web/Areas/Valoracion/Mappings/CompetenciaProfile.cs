using AutoMapper;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Features.Valoracion.Competencias.Queries.GetById;
using WordVision.ec.Domain.Entities.Valoracion;
using WordVision.ec.Web.Areas.Valoracion.Models;

namespace WordVision.ec.Web.Areas.Valoracion.Mappings
{
    public class CompetenciaProfile : Profile
    {
        public CompetenciaProfile()
        {
            
            
            CreateMap<GetCompetenciaByIdResponse, CompetenciaViewModel>().ReverseMap();
            CreateMap<Competencia, CompetenciaViewModel>().ReverseMap();

        }
    }
}
