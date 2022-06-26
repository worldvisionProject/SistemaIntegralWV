using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EParroquias
{
    public class DeleteEParroquiaCommand : IRequest<Result<int>>
    {
        public string Id { get; set; }

        public class DeleteEParroquiaCommandHandler : IRequestHandler<DeleteEParroquiaCommand, Result<int>>
        {
            private readonly IEParroquiaRepository _eParroquiaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEParroquiaCommandHandler(IEParroquiaRepository eParroquiaRepository, IUnitOfWork unitOfWork)
            {
                _eParroquiaRepository = eParroquiaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEParroquiaCommand request, CancellationToken cancellationToken)
            {
                var EParroquia = await _eParroquiaRepository.GetByIdAsync(request.Id);

                if (EParroquia == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eParroquiaRepository.DeleteAsync(EParroquia);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EParroquia.Id);
                }

            }
        }

    }
}
