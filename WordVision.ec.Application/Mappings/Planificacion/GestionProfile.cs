using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllCached;
using WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class GestionProfile : Profile
    {
        public GestionProfile()
        {
            CreateMap<CreateGestionCommand, Gestion>().ReverseMap();
            CreateMap<GetGestionByIdResponse, Gestion>().ReverseMap();
            CreateMap<GetAllGestionesCachedResponse, Gestion>().ReverseMap();

        }
    }
}
