using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Delete
{
    public class DeleteModeloProyectoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteModeloProyectoCommandHandler : IRequestHandler<DeleteModeloProyectoCommand, Result<int>>
        {
            private readonly IModeloProyectoRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteModeloProyectoCommandHandler(IModeloProyectoRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteModeloProyectoCommand command, CancellationToken cancellationToken)
            {
                var modeloProyecto = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(modeloProyecto);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(modeloProyecto.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El ModeloProyecto con Código: {modeloProyecto.Codigo} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
