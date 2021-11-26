using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Web.Areas.Planificacion.Models;

namespace WordVision.ec.Web.Areas.Planificacion.Mappings
{
    internal class GestionProfile : Profile
    {
        public GestionProfile()
        {
            CreateMap<GetAllGestionesCachedResponse, GestionViewModel>().ReverseMap();
            CreateMap<GetGestionByIdResponse, GestionViewModel>().ReverseMap();
            CreateMap<CreateGestionCommand, GestionViewModel>().ReverseMap();
            CreateMap<UpdateGestionCommand, GestionViewModel>().ReverseMap();
            CreateMap<Gestion, GestionViewModel>().ReverseMap();
        }
    }
}
