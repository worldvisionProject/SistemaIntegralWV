using AutoMapper;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetAllPaged;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class FormualrioProfile : Profile
    {
        public FormualrioProfile()
        {
            CreateMap<CreateFormularioCommand, Formulario>().ReverseMap();
            CreateMap<GetFormularioByIdResponse, Formulario>().ReverseMap();
            CreateMap<GetAllFormulariosCachedResponse, Formulario>().ReverseMap();
            CreateMap<GetAllFormulariosResponse, Formulario>().ReverseMap();
        }
    }
}
