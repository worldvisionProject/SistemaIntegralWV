using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadorUsuarios
{
    public class DeleteEIndicadorUsuarioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEIndicadorUsuarioCommandHandler : IRequestHandler<DeleteEIndicadorUsuarioCommand, Result<int>>
        {
            private readonly IEIndicadorUsuarioRepository _eIndicadorUsuarioRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEIndicadorUsuarioCommandHandler(IEIndicadorUsuarioRepository eIndicadorUsuarioRepository, IUnitOfWork unitOfWork)
            {
                _eIndicadorUsuarioRepository = eIndicadorUsuarioRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEIndicadorUsuarioCommand request, CancellationToken cancellationToken)
            {
                var EIndicadorUsuario = await _eIndicadorUsuarioRepository.GetByIdAsync(request.Id);

                if (EIndicadorUsuario == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eIndicadorUsuarioRepository.DeleteAsync(EIndicadorUsuario);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(EIndicadorUsuario.Id);
                }

            }
        }

    }
}
