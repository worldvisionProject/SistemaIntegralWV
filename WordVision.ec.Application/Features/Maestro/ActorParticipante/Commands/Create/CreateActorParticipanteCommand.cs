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
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Create
{
    public class CreateActorParticipanteCommand : ActorParticipanteResponse, IRequest<Result<int>>
    {
    }

    public class CreateActorParticipanteCommandHandler : IRequestHandler<CreateActorParticipanteCommand, Result<int>>
    {
        private readonly IActorParticipanteRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateActorParticipanteCommandHandler(IActorParticipanteRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateActorParticipanteCommand request, CancellationToken cancellationToken)
        {
            var actorParticipante = _mapper.Map<Domain.Entities.Maestro.ActorParticipante>(request);
            if (!await ValidateInsert(actorParticipante))
            {
                await _repository.InsertAsync(actorParticipante);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"ActorParticipante con Código: {request.Codigo} ya existe.");

            return Result<int>.Success(actorParticipante.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.ActorParticipante actor)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(actor);
            if (list.Count > 0)
                exist = true;
            return exist;

        }
    }
}
