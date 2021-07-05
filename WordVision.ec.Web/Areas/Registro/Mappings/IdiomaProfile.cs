using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Idiomas.Commands.Create;
using WordVision.ec.Application.Features.Registro.Idiomas.Commands.Update;
using WordVision.ec.Application.Features.Registro.Idiomas.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class IdiomaProfile : Profile
    {
        public IdiomaProfile()
        {
           
            CreateMap<GetByIdResponse, IdiomaViewModel>().ReverseMap();
            CreateMap<CreateIdiomaCommand, IdiomaViewModel>().ReverseMap();
            CreateMap<UpdateIdiomaCommand, IdiomaViewModel>().ReverseMap();
        }
    }
}
