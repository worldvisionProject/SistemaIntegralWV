using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Donacion.Interaciones.Commands.Create;
using WordVision.ec.Domain.Entities.Donacion;

namespace WordVision.ec.Application.Mappings.Donacion
{
    public class InteracionProfile : Profile
    {
        public InteracionProfile()
        {
            CreateMap<CreateInteracionCommand, Interacion>().ReverseMap();

        }
    }
}

