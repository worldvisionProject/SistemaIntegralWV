using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProyectos
{
    public class DeleteEProyectoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEProyectoCommandHandler : IRequestHandler<DeleteEProyectoCommand, Result<int>>
        {
            private readonly IEProyectoRepository _eProyectoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEProyectoCommandHandler(IEProyectoRepository eProyectoRepository, IUnitOfWork unitOfWork)
            {
                _eProyectoRepository = eProyectoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEProyectoCommand request, CancellationToken cancellationToken)
            {
                var eProyecto = await _eProyectoRepository.GetByIdAsync(request.Id);

                if (eProyecto == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eProyectoRepository.DeleteAsync(eProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(eProyecto.Id);
                }

            }
        }

    }
}
