using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Create;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Update;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class RcNinoPatrocinadoProfile : Profile
    {
        public RcNinoPatrocinadoProfile()
        {
            CreateMap<CreateRCNinoPatrocinadoCommand, RCNinoPatrocinado>().ReverseMap();
            CreateMap<RCNinoPatrocinadoResponse, RCNinoPatrocinado>().ReverseMap();
            CreateMap<UpdateRCNinoPatrocinadoCommand, RCNinoPatrocinado>().ReverseMap();
            CreateMap<GetAllRCNinoPatrocinadoQuery, RCNinoPatrocinado>().ReverseMap();
        }
       
    }
}
