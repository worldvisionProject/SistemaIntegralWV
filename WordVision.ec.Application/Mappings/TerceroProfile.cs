using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Terceros.Commands.Create;
using WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Mappings
{
    internal class TerceroProfile: Profile
    {
        public TerceroProfile()
        {
            CreateMap<CreateTerceroCommand, Tercero>().ReverseMap();
            CreateMap<GetByIdResponse, Tercero>().ReverseMap();
        
        }
    }
}
