using AutoMapper;
using WordVision.ec.Application.Features.Soporte.Ponentes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Ponentes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Ponentes.Queries.GetAll;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Application.Mappings.Soporte
{
    public class SolicitudProfile : Profile
    {
        public SolicitudProfile()
        {
            CreateMap<CreateSolicitudCommand, Solicitud>().ReverseMap();
            CreateMap<GetSolicitudByIdResponse, Solicitud>().ReverseMap();
            CreateMap<UpdateSolicitudCommand, Solicitud>().ReverseMap();

            CreateMap<CreatePonenteCommand, Ponente>().ReverseMap();
            CreateMap<UpdatePonenteCommand, Ponente>().ReverseMap();
            CreateMap<GetPonenteByIdResponse, Ponente>().ReverseMap();
            CreateMap<GetAllPonentesResponse, Ponente>().ReverseMap();

        }
    }
}
