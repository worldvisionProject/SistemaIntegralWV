using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Donacion.Debitos.Commands.Delete
{

    public class DeleteDebitoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteDebitoCommandHandler : IRequestHandler<DeleteDebitoCommand, Result<int>>
        {
            private readonly IDebitoRepository _debitoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteDebitoCommandHandler(IDebitoRepository debitoRepository, IUnitOfWork unitOfWork)
            {
                _debitoRepository = debitoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteDebitoCommand command, CancellationToken cancellationToken)
            {
                var debito = await _debitoRepository.GetByIdAsync(command.Id);
                await _debitoRepository.DeleteAsync(debito);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(debito.Id);
            }
        }
    }

}
