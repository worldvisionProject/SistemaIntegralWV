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

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Commands.Update
{
    public class UpdateLogFrameCommand : LogFrameResponse, IRequest<Result<int>>
    {
    }

    public class UpdateLogFrameCommandHandler : IRequestHandler<UpdateLogFrameCommand, Result<int>>
    {
        private readonly ILogFrameRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateLogFrameCommandHandler(ILogFrameRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateLogFrameCommand update, CancellationToken cancellationToken)
        {
            var logFrame = await _repository.GetByIdAsync(update.Id);

            if (logFrame == null)
            {
                return Result<int>.Fail($"LogFrame no encontrado.");
            }
            else
            {
                logFrame.OutPut = update.OutPut;
                logFrame.OutCome = update.OutCome;
                logFrame.Activity = update.Activity;
                logFrame.IdEstado = update.IdEstado;
                logFrame.IdNivel = update.IdNivel;
                logFrame.SumaryObjetives = update.SumaryObjetives;               

                await _repository.UpdateAsync(logFrame);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(logFrame.Id);
            }
        }
    }
}
