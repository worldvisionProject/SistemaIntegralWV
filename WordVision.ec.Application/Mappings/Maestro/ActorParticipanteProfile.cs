using AutoMapper;
using WordVision.ec.Application.Features.Maestro.ActorParticipante;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Create;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Update;
using WordVision.ec.Application.Features.Maestro.ActorParticipante.Queries.GetAll;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Mappings.Maestro
{
    internal class ActorParticipanteProfile : Profile
    {
        public ActorParticipanteProfile()
        {
            CreateMap<CreateActorParticipanteCommand, ActorParticipante>().ReverseMap();
            CreateMap<ActorParticipanteResponse, ActorParticipante>().ReverseMap();
            CreateMap<UpdateActorParticipanteCommand, ActorParticipante>().ReverseMap();
            CreateMap<GetAllActorParticipanteQuery, ActorParticipante>().ReverseMap();
        }
       
    }
}
