using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Create;
using WordVision.ec.Application.Features.Registro.Formularios.Commands.Update;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Formularios.Queries.GetById;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class FormualrioProfile : Profile
    {
        public FormualrioProfile()
        {
            CreateMap<GetAllFormulariosCachedResponse, FormularioViewModel>().ReverseMap();
            CreateMap<GetFormularioByIdResponse, FormularioViewModel>().ReverseMap();
            CreateMap<CreateFormularioCommand, FormularioViewModel>().ReverseMap();
            CreateMap<UpdateFormularioCommand, FormularioViewModel>().ReverseMap();
            CreateMap<UpdateFormularioPdfCommand, FormularioViewModel>().ReverseMap();
            CreateMap<UpdateColaboradorCommand, ColaboradorViewModel>().ReverseMap();
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Tercero, TerceroViewModel>().ReverseMap();
            CreateMap<FormularioTercero, FormularioTerceroViewModel>().ReverseMap();
            CreateMap<Idioma, IdiomaViewModel>().ReverseMap();
            CreateMap<Formulario, FormularioViewModel>().ReverseMap();
        }
    }
    }


