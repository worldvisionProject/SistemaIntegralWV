using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.ECantones
{
    public class DeleteECantonCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteECantonCommandHandler : IRequestHandler<DeleteECantonCommand, Result<int>>
        {
            private readonly IECantonRepository _eCantonRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteECantonCommandHandler(IECantonRepository eCantonRepository, IUnitOfWork unitOfWork)
            {
                _eCantonRepository = eCantonRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteECantonCommand request, CancellationToken cancellationToken)
            {
                var ECanton = await _eCantonRepository.GetByIdAsync(request.Id);

                if (ECanton == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eCantonRepository.DeleteAsync(ECanton);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(ECanton.Id);
                }

            }
        }

    }
}
