using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.MetaTacticas.Commands.Delete
{

    public class DeleteMetaTacticaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteMetaTacticaCommandHandler : IRequestHandler<DeleteMetaTacticaCommand, Result<int>>
        {
            private readonly IMetaTacticaRepository _MetaTacticaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteMetaTacticaCommandHandler(IMetaTacticaRepository MetaTacticaRepository, IUnitOfWork unitOfWork)
            {
                _MetaTacticaRepository = MetaTacticaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteMetaTacticaCommand command, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _MetaTacticaRepository.GetByIdAsync(command.Id);
                await _MetaTacticaRepository.DeleteAsync(IndicadorAF);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorAF.Id);
            }
        }
    }
}
