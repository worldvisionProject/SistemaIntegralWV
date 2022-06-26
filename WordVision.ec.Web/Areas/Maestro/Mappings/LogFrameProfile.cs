using AutoMapper;
using WordVision.ec.Application.Features.Maestro.LogFrame;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Create;
using WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class LogFrameProfile : Profile
    {
        public LogFrameProfile()
        {            
            CreateMap<LogFrameResponse, LogFrameViewModel>().ReverseMap();
            CreateMap<LogFrameIndicadorPRResponse, LogFrameIndicadorPRViewModel>().ReverseMap();
            CreateMap<CreateLogFrameCommand, LogFrameViewModel>().ReverseMap();
            CreateMap<UpdateLogFrameCommand, LogFrameViewModel>().ReverseMap();
        }
        
    }
}
