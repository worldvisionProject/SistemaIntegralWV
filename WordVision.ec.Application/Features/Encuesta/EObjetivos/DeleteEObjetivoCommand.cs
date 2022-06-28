using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EObjetivos
{
    public class DeleteEObjetivoCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteEObjetivoCommandHandler : IRequestHandler<DeleteEObjetivoCommand, Result<int>>
        {
            private readonly IEObjetivoRepository _eObjetivoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEObjetivoCommandHandler(IEObjetivoRepository eObjetivoRepository, IUnitOfWork unitOfWork)
            {
                _eObjetivoRepository = eObjetivoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEObjetivoCommand request, CancellationToken cancellationToken)
            {
                var EObjetivo = await _eObjetivoRepository.GetByIdAsync(request.Id);

                if (EObjetivo == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eObjetivoRepository.DeleteAsync(EObjetivo);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EObjetivo.Id);
                }

            }
        }

    }
}
