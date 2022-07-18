using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Delete
{
    public class DeletePresupuestoProyectoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeletePresupuestoProyectoCommandHandler : IRequestHandler<DeletePresupuestoProyectoCommand, Result<int>>
        {
            private readonly IPresupuestoProyectoRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeletePresupuestoProyectoCommandHandler(IPresupuestoProyectoRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeletePresupuestoProyectoCommand command, CancellationToken cancellationToken)
            {
                var presupuestoProyecto = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(presupuestoProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(presupuestoProyecto.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El PresupuestoProyecto con Id: {presupuestoProyecto.Id} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
