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

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Delete
{
    public class DeleteFactorCriticoExitoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteFactorCriticoExitoCommandHandler : IRequestHandler<DeleteFactorCriticoExitoCommand, Result<int>>
        {
            private readonly IFactorCriticoExitoRepository _FactorCriticoExitoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteFactorCriticoExitoCommandHandler(IFactorCriticoExitoRepository FactorCriticoExitoRepository, IUnitOfWork unitOfWork)
            {
                _FactorCriticoExitoRepository = FactorCriticoExitoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteFactorCriticoExitoCommand command, CancellationToken cancellationToken)
            {
                var FactorCriticoExito = await _FactorCriticoExitoRepository.GetByIdAsync(command.Id);
                await _FactorCriticoExitoRepository.DeleteAsync(FactorCriticoExito);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(FactorCriticoExito.Id);
            }
        }
    }
}
