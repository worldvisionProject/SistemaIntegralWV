using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorVinculadoEs.Commands.Delete
{
    public class DeleteIndicadorVinculadoECommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorVinculadoECommandHandler : IRequestHandler<DeleteIndicadorVinculadoECommand, Result<int>>
        {
            private readonly IIndicadorVinculadoCERepository _indicadorVinculadoCERepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorVinculadoECommandHandler(IIndicadorVinculadoCERepository indicadorVinculadoCERepository, IUnitOfWork unitOfWork)
            {
                _indicadorVinculadoCERepository = indicadorVinculadoCERepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorVinculadoECommand command, CancellationToken cancellationToken)
            {
                var IndicadorPOA = await _indicadorVinculadoCERepository.GetByIdAsync(command.Id);
                await _indicadorVinculadoCERepository.DeleteAsync(IndicadorPOA);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorPOA.Id);
            }
        }
    }
}
