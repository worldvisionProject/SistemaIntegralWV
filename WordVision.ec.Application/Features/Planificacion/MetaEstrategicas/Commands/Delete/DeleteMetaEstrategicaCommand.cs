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

namespace WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Commands.Delete
{
    public class DeleteMetaEstrategicaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteMetaEstrategicaCommandHandler : IRequestHandler<DeleteMetaEstrategicaCommand, Result<int>>
        {
            private readonly IMetaEstrategicaRepository _metaEstrategicaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteMetaEstrategicaCommandHandler(IMetaEstrategicaRepository metaEstrategicaRepository, IUnitOfWork unitOfWork)
            {
                _metaEstrategicaRepository = metaEstrategicaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteMetaEstrategicaCommand command, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _metaEstrategicaRepository.GetByIdAsync(command.Id);
                await _metaEstrategicaRepository.DeleteAsync(IndicadorAF);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorAF.Id);
            }
        }

    }
}
