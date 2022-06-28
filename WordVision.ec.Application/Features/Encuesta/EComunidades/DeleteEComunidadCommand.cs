using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EComunidades
{
    public class DeleteEComunidadCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteEComunidadCommandHandler : IRequestHandler<DeleteEComunidadCommand, Result<int>>
        {
            private readonly IEComunidadRepository _eComunidadRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEComunidadCommandHandler(IEComunidadRepository eComunidadRepository, IUnitOfWork unitOfWork)
            {
                _eComunidadRepository = eComunidadRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEComunidadCommand request, CancellationToken cancellationToken)
            {
                var EComunidad = await _eComunidadRepository.GetByIdAsync(request.Id);

                if (EComunidad == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eComunidadRepository.DeleteAsync(EComunidad);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EComunidad.Id);
                }

            }
        }

    }
}
