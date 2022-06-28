using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete
{

    public class DeletePlanificacionComportamientoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeletePlanificacionComportamientoCommandHandler : IRequestHandler<DeletePlanificacionComportamientoCommand, Result<int>>
        {
            private readonly IPlanificacionComportamientoRepository _planificacionComportamientoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeletePlanificacionComportamientoCommandHandler(IPlanificacionComportamientoRepository planificacionComportamientoRepository, IUnitOfWork unitOfWork)
            {
                _planificacionComportamientoRepository = planificacionComportamientoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePlanificacionComportamientoCommand command, CancellationToken cancellationToken)
            {
                var Actividad = await _planificacionComportamientoRepository.GetByIdAsync(command.Id);
                if (Actividad!=null)
                {
                    await _planificacionComportamientoRepository.DeleteAsync(Actividad);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(Actividad.Id);
                }
                else
                {
                    return Result<int>.Success(command.Id);
                }
               
                
            }
        }
    }

}
