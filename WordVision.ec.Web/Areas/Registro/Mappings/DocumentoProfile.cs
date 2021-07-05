using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Firma.Commands.Create;
using WordVision.ec.Application.Features.Registro.Respuestas.Commands.Create;
using WordVision.ec.Application.Features.Registro.Respuestas.Commands.Update;
using WordVision.ec.Application.Features.Registro.Respuestas.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class DocumentoProfile:Profile
    {
        public DocumentoProfile()
        {
            CreateMap<GetAllDocumentosCachedResponse, DocumentoViewModel>().ReverseMap();
            CreateMap<GetDocumentoByIdResponse, DocumentoViewModel>().ReverseMap();
            CreateMap<CreateRespuestaCommand, RespuestaViewModel>().ReverseMap();
            CreateMap<UpdateRespuestaCommand, RespuestaViewModel>().ReverseMap();
            CreateMap<GetRespuestaByIdResponse, RespuestaViewModel>().ReverseMap();
            CreateMap<CreateFirmaCommand, FirmaViewModel>().ReverseMap();
        }
    }
}
