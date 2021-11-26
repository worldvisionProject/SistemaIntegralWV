using AutoMapper;
using WordVision.ec.Application.Features.Registro.Documentos.Commands.Create;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllPaged;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Respuestas.Commands.Create;
using WordVision.ec.Application.Features.Registro.Respuestas.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class DocumentosProfile : Profile
    {
        public DocumentosProfile()
        {
            CreateMap<CreateDocumentoCommand, Documento>().ReverseMap();
            CreateMap<GetDocumentoByIdResponse, Documento>().ReverseMap();
            CreateMap<GetAllDocumentosCachedResponse, Documento>().ReverseMap();
            CreateMap<GetAllDocumentosResponse, Documento>().ReverseMap();
            CreateMap<CreateRespuestaCommand, Respuesta>().ReverseMap();
            CreateMap<GetRespuestaByIdResponse, Respuesta>().ReverseMap();
        }
    }
}
