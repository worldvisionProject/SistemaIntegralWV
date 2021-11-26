using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Commands.Delete
{
    public class DeleteIndicadorAFCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIndicadorAFCommandHandler : IRequestHandler<DeleteIndicadorAFCommand, Result<int>>
        {
            private readonly IIndicadorAFRepository _IndicadorAFRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIndicadorAFCommandHandler(IIndicadorAFRepository IndicadorAFRepository, IUnitOfWork unitOfWork)
            {
                _IndicadorAFRepository = IndicadorAFRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIndicadorAFCommand command, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _IndicadorAFRepository.GetByIdAsync(command.Id);
                await _IndicadorAFRepository.DeleteAsync(IndicadorAF);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorAF.Id);
            }
        }
    }
}
