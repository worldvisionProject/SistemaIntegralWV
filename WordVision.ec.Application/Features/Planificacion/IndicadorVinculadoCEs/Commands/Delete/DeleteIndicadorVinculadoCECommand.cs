using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorVinculadoCEs.Commands.Delete
{
    public class DeleteIndicadorVinculadoCECommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorVinculadoCECommandHandler : IRequestHandler<DeleteIndicadorVinculadoCECommand, Result<int>>
        {
            private readonly IIndicadorVinculadoCERepository _indicadorVinculadoCERepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorVinculadoCECommandHandler(IIndicadorVinculadoCERepository indicadorVinculadoCERepository, IUnitOfWork unitOfWork)
            {
                _indicadorVinculadoCERepository = indicadorVinculadoCERepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorVinculadoCECommand command, CancellationToken cancellationToken)
            {
                var IndicadorPOA = await _indicadorVinculadoCERepository.GetByIdAsync(command.Id);
                await _indicadorVinculadoCERepository.DeleteAsync(IndicadorPOA);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorPOA.Id);
            }
        }
    }
}
