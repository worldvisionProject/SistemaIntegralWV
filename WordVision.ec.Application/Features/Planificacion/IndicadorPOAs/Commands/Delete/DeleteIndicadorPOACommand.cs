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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Delete
{
    public class DeleteIndicadorPOACommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorPOACommandHandler : IRequestHandler<DeleteIndicadorPOACommand, Result<int>>
        {
            private readonly IIndicadorPOARepository _IndicadorPOARepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorPOACommandHandler(IIndicadorPOARepository IndicadorPOARepository, IUnitOfWork unitOfWork)
            {
                _IndicadorPOARepository = IndicadorPOARepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorPOACommand command, CancellationToken cancellationToken)
            {
                var IndicadorPOA = await _IndicadorPOARepository.GetByIdAsync(command.Id);
                await _IndicadorPOARepository.DeleteAsync(IndicadorPOA);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorPOA.Id);
            }
        }
    }
}
