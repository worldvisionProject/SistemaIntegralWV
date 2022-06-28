using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete
{

    public class DeletePlanificacionResultadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeletePlanificacionResultadoCommandHandler : IRequestHandler<DeletePlanificacionResultadoCommand, Result<int>>
        {
            private readonly IPlanificacionResultadoRepository _planificacionResultadoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeletePlanificacionResultadoCommandHandler(IPlanificacionResultadoRepository planificacionResultadoRepository, IUnitOfWork unitOfWork)
            {
                _planificacionResultadoRepository = planificacionResultadoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePlanificacionResultadoCommand command, CancellationToken cancellationToken)
            {
                var Actividad = await _planificacionResultadoRepository.GetByIdAsync(command.Id);
                await _planificacionResultadoRepository.DeleteAsync(Actividad);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Actividad.Id);
            }
        }
    }

}
