using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Commands.Delete
{
    public class DeleteObjetivoEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteObjetivoEstrategicoCommandHandler : IRequestHandler<DeleteObjetivoEstrategicoCommand, Result<int>>
        {
            private readonly IObjetivoEstrategicoRepository _ObjetivoEstrategicoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteObjetivoEstrategicoCommandHandler(IObjetivoEstrategicoRepository ObjetivoEstrategicoRepository, IUnitOfWork unitOfWork)
            {
                _ObjetivoEstrategicoRepository = ObjetivoEstrategicoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteObjetivoEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var ObjetivoEstrategico = await _ObjetivoEstrategicoRepository.GetByIdAsync(command.Id);
                await _ObjetivoEstrategicoRepository.DeleteAsync(ObjetivoEstrategico);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(ObjetivoEstrategico.Id);
            }
        }

    }
}
