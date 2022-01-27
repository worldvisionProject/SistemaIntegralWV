using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete
{

    public class DeletePlanificacionHitoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeletePlanificacionHitoCommandHandler : IRequestHandler<DeletePlanificacionHitoCommand, Result<int>>
        {
            private readonly IPlanificacionHitoRepository _planificacionHitoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeletePlanificacionHitoCommandHandler(IPlanificacionHitoRepository planificacionHitoRepository, IUnitOfWork unitOfWork)
            {
                _planificacionHitoRepository = planificacionHitoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePlanificacionHitoCommand command, CancellationToken cancellationToken)
            {
                var Actividad = await _planificacionHitoRepository.GetByIdAsync(command.Id);
                if (Actividad!=null)
                {
                    await _planificacionHitoRepository.DeleteAsync(Actividad);
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
