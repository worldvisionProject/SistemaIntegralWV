using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class ProgramaAreaProfile : Profile
    {
        public ProgramaAreaProfile()
        {            
            CreateMap<ProgramaAreaResponse, ProgramaAreaViewModel>().ReverseMap();
            CreateMap<CreateProgramaAreaCommand, ProgramaAreaViewModel>().ReverseMap();
            CreateMap<UpdateProgramaAreaCommand, ProgramaAreaViewModel>().ReverseMap();
        }
        
    }
}
