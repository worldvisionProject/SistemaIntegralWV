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

namespace WordVision.ec.Application.Features.Maestro.ActorParticipante.Queries.GetAll
{
    public class GetAllActorParticipanteQuery : ActorParticipanteResponse, IRequest<Result<List<ActorParticipanteResponse>>>
    {
    }

    public class GetAllActorParticipanteQueryHandler : IRequestHandler<GetAllActorParticipanteQuery, Result<List<ActorParticipanteResponse>>>
    {
        private readonly IActorParticipanteRepository _repository;
        private readonly IMapper _mapper;

        public GetAllActorParticipanteQueryHandler(IActorParticipanteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ActorParticipanteResponse>>> Handle(GetAllActorParticipanteQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ActorParticipante>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ActorParticipanteResponse>>(list);

            return Result<List<ActorParticipanteResponse>>.Success(responseList);
        }
    }
}
