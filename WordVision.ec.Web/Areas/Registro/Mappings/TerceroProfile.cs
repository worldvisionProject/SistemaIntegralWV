using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Create;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Update;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;
using WordVision.ec.Web.Areas.Registro.Models;

namespace WordVision.ec.Web.Areas.Registro.Mappings
{
    internal class TerceroProfile: Profile
    {
        public TerceroProfile()
        {
            CreateMap<CreateTerceroCommand, TerceroViewModel>().ReverseMap();
            CreateMap<GetByIdResponse, TerceroViewModel>().ReverseMap();
            CreateMap<UpdateTerceroCommand, TerceroViewModel>().ReverseMap();

        }
    }
}
