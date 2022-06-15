using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ActorParticipante;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Update;
using WordVision.ec.Web.Areas.Maestro.Models;

namespace WordVision.ec.Web.Areas.Maestro.Mappings
{
    internal class ActorParticipanteProfile : Profile
    {
        public ActorParticipanteProfile()
        {            
            CreateMap<ActorParticipanteResponse, ActorParticipanteViewModel>().ReverseMap();
            CreateMap<CreateActorParticipanteCommand, ActorParticipanteViewModel>().ReverseMap();
            CreateMap<UpdateActorParticipanteCommand, ActorParticipanteViewModel>().ReverseMap();
        }
        
    }
}
