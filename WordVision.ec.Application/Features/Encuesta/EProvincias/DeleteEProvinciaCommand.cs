using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProvincias
{
    public class DeleteEProvinciaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteEProvinciaCommandHandler : IRequestHandler<DeleteEProvinciaCommand, Result<int>>
        {
            private readonly IEProvinciaRepository _eProvinciaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEProvinciaCommandHandler(IEProvinciaRepository eProvinciaRepository, IUnitOfWork unitOfWork)
            {
                _eProvinciaRepository = eProvinciaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEProvinciaCommand request, CancellationToken cancellationToken)
            {
                var EProvincia = await _eProvinciaRepository.GetByIdAsync(request.Id);

                if (EProvincia == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eProvinciaRepository.DeleteAsync(EProvincia);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EProvincia.Id);
                }

            }
        }

    }
}
