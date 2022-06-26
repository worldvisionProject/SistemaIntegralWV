using AutoMapper;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Create;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class RcNinoPatrocinadoProfile : Profile
    {
        public RcNinoPatrocinadoProfile()
        {            
            CreateMap<RCNinoPatrocinadoResponse, RcNinoPatrocinadoViewModel>().ReverseMap();
            CreateMap<CreateRCNinoPatrocinadoCommand, RcNinoPatrocinadoViewModel>().ReverseMap();
            CreateMap<UpdateRCNinoPatrocinadoCommand, RcNinoPatrocinadoViewModel>().ReverseMap();
        }
        
    }
}
