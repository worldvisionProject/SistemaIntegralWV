using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Create;
using WordVision.ec.Application.Features.Registro.Colaboradores.Commands.Update;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class ColaboradorProfile : Profile
    {
        public ColaboradorProfile()
        {
            CreateMap<GetAllColaboradoresCachedResponse, ColaboradorViewModel>().ReverseMap();
            CreateMap<GetColaboradorByIdResponse, ColaboradorViewModel>().ReverseMap();
            CreateMap<CreateColaboradorCommand, ColaboradorViewModel>().ReverseMap();
            CreateMap<UpdateColaboradorCommand, ColaboradorViewModel>().ReverseMap();
        }
    }
}
