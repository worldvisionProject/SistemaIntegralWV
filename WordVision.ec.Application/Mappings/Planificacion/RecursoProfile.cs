using AutoMapper;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Create;
using WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Update;
using WordVision.ec.Application.Features.Planificacion.Recursos.Queries.GetById;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Mappings.Planificacion
{
    public class RecursoProfile : Profile
    {
        public RecursoProfile()
        {
            CreateMap<CreateRecursoCommand, Recurso>().ReverseMap();
            CreateMap<GetRecursoByIdResponse, Recurso>().ReverseMap();
            CreateMap<UpdateRecursoCommand, Recurso>().ReverseMap();

        }
    }
}
