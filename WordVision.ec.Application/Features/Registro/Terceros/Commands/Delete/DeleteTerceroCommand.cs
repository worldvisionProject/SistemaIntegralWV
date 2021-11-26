using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Terceros.Commands.Delete
{
    public class DeleteTerceroCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteTerceroCommandHandler : IRequestHandler<DeleteTerceroCommand, Result<int>>
        {
            private readonly ITerceroRepository _TerceroRepository;
            private readonly IFormularioTerceroRepository _formularioTerceroRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteTerceroCommandHandler(IFormularioTerceroRepository formularioTerceroRepository, ITerceroRepository TerceroRepository, IUnitOfWork unitOfWork)
            {
                _TerceroRepository = TerceroRepository;
                _formularioTerceroRepository = formularioTerceroRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteTerceroCommand command, CancellationToken cancellationToken)
            {
                var tercero = await _TerceroRepository.GetByIdAsync(command.Id);
                await _TerceroRepository.DeleteAsync(tercero);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(tercero.Id);
            }
        }

    }
}
