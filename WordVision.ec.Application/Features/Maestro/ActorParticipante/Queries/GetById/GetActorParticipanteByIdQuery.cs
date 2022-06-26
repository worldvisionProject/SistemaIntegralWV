using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ActorParticipante.Queries.GetById
{
    public class GetActorParticipanteByIdQuery : ActorParticipanteResponse, IRequest<Result<ActorParticipanteResponse>>
    {
    }

    public class GetActorParticipanteByIdQueryHandler : IRequestHandler<GetActorParticipanteByIdQuery, Result<ActorParticipanteResponse>>
    {
        private readonly IActorParticipanteRepository _repository;
        private readonly IMapper _mapper;

        public GetActorParticipanteByIdQueryHandler(IActorParticipanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ActorParticipanteResponse>> Handle(GetActorParticipanteByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ActorParticipanteResponse>(result);

            return Result<ActorParticipanteResponse>.Success(response);
        }
    }
}
