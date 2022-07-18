using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Delete
{
    public class DeleteActorParticipanteCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteActorParticipanteCommandHandler : IRequestHandler<DeleteActorParticipanteCommand, Result<int>>
        {
            private readonly IActorParticipanteRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteActorParticipanteCommandHandler(IActorParticipanteRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteActorParticipanteCommand command, CancellationToken cancellationToken)
            {
                var actorParticipante = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(actorParticipante);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(actorParticipante.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El Actor/Participante con Código: {actorParticipante.Codigo} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
