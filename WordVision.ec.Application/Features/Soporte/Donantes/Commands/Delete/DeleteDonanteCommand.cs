using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Commands.Delete
{

    public class DeleteDonanteCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteDonanteCommandHandler : IRequestHandler<DeleteDonanteCommand, Result<int>>
        {
            private readonly IDonanteRepository _donanteRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteDonanteCommandHandler(IDonanteRepository donanteRepository, IUnitOfWork unitOfWork)
            {
                _donanteRepository = donanteRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteDonanteCommand command, CancellationToken cancellationToken)
            {
                var Donante = await _donanteRepository.GetByIdAsync(command.Id);
                await _donanteRepository.DeleteAsync(Donante);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Donante.Id);
            }
        }
    }

}
