using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class PreguntaProfile : Profile
    {
        public PreguntaProfile()
        {
            CreateMap<GetAllPreguntasCachedResponse, PreguntaViewModel>().ReverseMap();
            CreateMap<GetPreguntaByIdResponse, PreguntaViewModel>().ReverseMap();
            CreateMap<GetPreguntasByIdDocumentoResponse, PreguntaViewModel>().ReverseMap();

        }
    }
}

