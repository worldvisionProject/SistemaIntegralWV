using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ProgramaArea;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class ProgramaAreaProfile : Profile
    {
        public ProgramaAreaProfile()
        {
            CreateMap<CreateProgramaAreaCommand, ProgramaArea>().ReverseMap();
            CreateMap<ProgramaAreaResponse, ProgramaArea>().ReverseMap();
            CreateMap<UpdateProgramaAreaCommand, ProgramaArea>().ReverseMap();
            CreateMap<GetAllProgramaAreaQuery, ProgramaArea>().ReverseMap();
        }
       
    }
}
