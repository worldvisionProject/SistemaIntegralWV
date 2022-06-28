using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ActorParticipante.Commands.Update
{
    public class UpdateActorParticipanteCommand : ActorParticipanteResponse, IRequest<Result<int>>
    {
    }

    public class UpdateActorParticipanteCommandHandler : IRequestHandler<UpdateActorParticipanteCommand, Result<int>>
    {
        private readonly IActorParticipanteRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateActorParticipanteCommandHandler(IActorParticipanteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateActorParticipanteCommand update, CancellationToken cancellationToken)
        {
            var actorParticipante = await _repository.GetByIdAsync(update.Id);

            if (actorParticipante == null)
            {
                return Result<int>.Fail($"ActorParticipante no encontrado.");
            }
            else
            {
                var list = await _repository.GetListAsync(new Domain.Entities.Maestro.ActorParticipante());
                if (list.Where(r => r.Codigo == update.Codigo && r.Id != update.Id).Count() > 0)
                    return Result<int>.Fail($"ActorParticipante con Código: {update.Codigo} ya existe.");

                actorParticipante.Codigo = update.Codigo;
                actorParticipante.Descripcion = update.Descripcion;
                actorParticipante.ActoresParticipantes = update.ActoresParticipantes;
                actorParticipante.IdEstado = update.IdEstado;             

                await _repository.UpdateAsync(actorParticipante);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(actorParticipante.Id);
            }
        }
    }
}
