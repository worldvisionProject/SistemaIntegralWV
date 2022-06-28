using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadores
{
    public class DeleteEIndicadorCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteEIndicadorCommandHandler : IRequestHandler<DeleteEIndicadorCommand, Result<int>>
        {
            private readonly IEIndicadorRepository _eIndicadorRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEIndicadorCommandHandler(IEIndicadorRepository eIndicadorRepository, IUnitOfWork unitOfWork)
            {
                _eIndicadorRepository = eIndicadorRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEIndicadorCommand request, CancellationToken cancellationToken)
            {
                var EIndicador = await _eIndicadorRepository.GetByIdAsync(request.Id);

                if (EIndicador == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eIndicadorRepository.DeleteAsync(EIndicador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EIndicador.Id);
                }

            }
        }

    }
}
