using AutoMapper;
using WordVision.ec.Application.Features.Maestro.OtroIndicador;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Create;
using WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class OtroIndicadorProfile : Profile
    {
        public OtroIndicadorProfile()
        {            
            CreateMap<OtroIndicadorResponse, OtroIndicadorViewModel>().ReverseMap();
            CreateMap<CreateOtroIndicadorCommand, OtroIndicadorViewModel>().ReverseMap();
            CreateMap<UpdateOtroIndicadorCommand, OtroIndicadorViewModel>().ReverseMap();
        }
        
    }
}
