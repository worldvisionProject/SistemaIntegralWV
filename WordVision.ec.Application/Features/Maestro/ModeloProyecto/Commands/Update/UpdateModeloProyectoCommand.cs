using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.ModeloProyecto.Commands.Update
{
    public class UpdateModeloProyectoCommand : ModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateModeloProyectoCommandHandler : IRequestHandler<UpdateModeloProyectoCommand, Result<int>>
    {
        private readonly IModeloProyectoRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateModeloProyectoCommandHandler(IModeloProyectoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateModeloProyectoCommand update, CancellationToken cancellationToken)
        {
            var modeloProyecto = await _repository.GetByIdAsync(update.Id);

            if (modeloProyecto == null)
            {
                return Result<int>.Fail($"ModeloProyecto no encontrado.");
            }
            else
            {
                var list = await _repository.GetListAsync(new Domain.Entities.Maestro.ModeloProyecto());
                if (list.Where(r => r.Codigo == update.Codigo && r.Id != update.Id).Count() > 0)
                    return Result<int>.Fail($"ModeloProyecto con Código: {update.Codigo} ya existe.");

                modeloProyecto.Descripcion = update.Descripcion;
                modeloProyecto.IdEstado = update.IdEstado;
                modeloProyecto.IdEtapaModeloProyecto = update.IdEtapaModeloProyecto;            

                await _repository.UpdateAsync(modeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(modeloProyecto.Id);
            }
        }
    }
}
