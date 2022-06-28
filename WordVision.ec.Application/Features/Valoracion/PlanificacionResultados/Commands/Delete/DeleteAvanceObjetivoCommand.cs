using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Delete
{
    public class DeleteAvanceObjetivoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteAvanceObjetivoCommandHandler : IRequestHandler<DeleteAvanceObjetivoCommand, Result<int>>
        {
            private readonly IAvanceObjetivoRepository _avanceRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteAvanceObjetivoCommandHandler(IAvanceObjetivoRepository avanceRepository, IUnitOfWork unitOfWork)
            {
                _avanceRepository = avanceRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteAvanceObjetivoCommand command, CancellationToken cancellationToken)
            {
                var avance = await _avanceRepository.GetByIdAsync(command.Id);
                if (avance != null)
                {
                    await _avanceRepository.DeleteAsync(avance);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(avance.Id);
                }
                else
                {
                    return Result<int>.Success(command.Id);
                }


            }
        }
    }
}
