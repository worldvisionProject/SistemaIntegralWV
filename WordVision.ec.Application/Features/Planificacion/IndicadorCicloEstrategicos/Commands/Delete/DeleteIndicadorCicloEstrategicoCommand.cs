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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Delete
{
    public class DeleteIndicadorCicloEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorCicloEstrategicoCommandHandler : IRequestHandler<DeleteIndicadorCicloEstrategicoCommand, Result<int>>
        {
            private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorCicloEstrategicoCommandHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IUnitOfWork unitOfWork)
            {
                _entidadRepository = entidadRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorCicloEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);
                await _entidadRepository.DeleteAsync(obj);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);
            }
        }

    }
}
