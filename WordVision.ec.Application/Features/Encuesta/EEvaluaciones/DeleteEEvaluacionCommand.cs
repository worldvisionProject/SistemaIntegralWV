using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EEvaluaciones
{
    public class DeleteEEvaluacionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEEvaluacionCommandHandler : IRequestHandler<DeleteEEvaluacionCommand, Result<int>>
        {
            private readonly IEEvaluacionRepository _eEvaluacionRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEEvaluacionCommandHandler(IEEvaluacionRepository eEvaluacionRepository, IUnitOfWork unitOfWork)
            {
                _eEvaluacionRepository = eEvaluacionRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEEvaluacionCommand request, CancellationToken cancellationToken)
            {
                var eEvaluacion = await _eEvaluacionRepository.GetByIdAsync(request.Id);

                if (eEvaluacion == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eEvaluacionRepository.DeleteAsync(eEvaluacion);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(eEvaluacion.Id);
                }

            }
        }

    }
}
