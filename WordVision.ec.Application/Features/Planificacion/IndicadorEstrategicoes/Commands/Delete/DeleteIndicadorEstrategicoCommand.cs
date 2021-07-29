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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Delete
{
    public class DeleteIndicadorEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorEstrategicoCommandHandler : IRequestHandler<DeleteIndicadorEstrategicoCommand, Result<int>>
        {
            private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorEstrategicoCommandHandler(IIndicadorEstrategicoRepository IndicadorEstrategicoRepository, IUnitOfWork unitOfWork)
            {
                _IndicadorEstrategicoRepository = IndicadorEstrategicoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var IndicadorEstrategico = await _IndicadorEstrategicoRepository.GetByIdAsync(command.Id,0);
                await _IndicadorEstrategicoRepository.DeleteAsync(IndicadorEstrategico);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorEstrategico.Id);
            }
        }
    }
}
