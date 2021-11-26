using AutoMapper;
using WordVision.ec.Application.Features.Soporte.Ponentes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Ponentes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Ponentes.Queries.GetAll;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Create;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Domain.Entities.Soporte;
using WordVision.ec.Web.Areas.Registro.Models;
using WordVision.ec.Web.Areas.Soporte.Models;

namespace WordVision.ec.Web.Areas.Soporte.Mappings
{
    public class SolicitudProfile : Profile
    {
        public SolicitudProfile()
        {
            CreateMap<CreateSolicitudCommand, SolicitudViewModel>().ReverseMap();
            CreateMap<GetSolicitudByIdResponse, SolicitudViewModel>().ReverseMap();
            CreateMap<UpdateSolicitudCommand, SolicitudViewModel>().ReverseMap();
            CreateMap<GetPonenteByIdResponse, PonenteViewModel>().ReverseMap();
            CreateMap<GetAllPonentesResponse, PonenteViewModel>().ReverseMap();

            CreateMap<CreatePonenteCommand, PonenteViewModel>().ReverseMap();
            CreateMap<UpdatePonenteCommand, PonenteViewModel>().ReverseMap();
            CreateMap<Solicitud, SolicitudViewModel>().ReverseMap();
            CreateMap<Mensajeria, MensajeriaViewModel>().ReverseMap();
            CreateMap<Comunicacion, ComunicacionViewModel>().ReverseMap();
            CreateMap<EstadosSolicitud, EstadosSolicitudViewModel>().ReverseMap();
            CreateMap<Ponente, PonenteViewModel>().ReverseMap();
            CreateMap<LogoSocio, LogoSocioViewModel>().ReverseMap();
            CreateMap<Colaborador, ColaboradorViewModel>().ForMember(d => d.Nombres, n => n.MapFrom(x => string.Format("{0} {1} {2} {3}", x.Apellidos, x.ApellidoMaterno, x.PrimerNombre, x.SegundoNombre)))
                            .ReverseMap();

        }
    }
}
