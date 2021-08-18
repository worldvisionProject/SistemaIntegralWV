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

namespace WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Delete
{
    public class DeleteTechoPresupuestarioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteTechoPresupuestarioCommandHandler : IRequestHandler<DeleteTechoPresupuestarioCommand, Result<int>>
        {
            private readonly ITechoPresupuestarioRepository _TechoPresupuestarioRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteTechoPresupuestarioCommandHandler(ITechoPresupuestarioRepository TechoPresupuestarioRepository, IUnitOfWork unitOfWork)
            {
                _TechoPresupuestarioRepository = TechoPresupuestarioRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteTechoPresupuestarioCommand command, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _TechoPresupuestarioRepository.GetByIdAsync(command.Id);
                await _TechoPresupuestarioRepository.DeleteAsync(IndicadorAF);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorAF.Id);
            }
        }

    }
}
