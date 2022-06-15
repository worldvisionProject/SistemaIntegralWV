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

namespace WordVision.ec.Application.Features.Maestro.EtapaModeloProyecto.Commands.Update
{
    public class UpdateEtapaModeloProyectoCommand : EtapaModeloProyectoResponse, IRequest<Result<int>>
    {
    }

    public class UpdateEtapaModeloProyectoCommandHandler : IRequestHandler<UpdateEtapaModeloProyectoCommand, Result<int>>
    {
        private readonly IEtapaModeloProyectoRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateEtapaModeloProyectoCommandHandler(IEtapaModeloProyectoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateEtapaModeloProyectoCommand update, CancellationToken cancellationToken)
        {
            var etapaModeloProyecto = await _repository.GetByIdAsync(update.Id);

            if (etapaModeloProyecto == null)
            {
                return Result<int>.Fail($"EtapaModeloProyecto no encontrado.");
            }
            else
            {
                etapaModeloProyecto.IdAccionOperativa = update.IdAccionOperativa;
                etapaModeloProyecto.IdEstado = update.IdEstado;
                etapaModeloProyecto.Etapa = update.Etapa;            

                await _repository.UpdateAsync(etapaModeloProyecto);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(etapaModeloProyecto.Id);
            }
        }
    }
}
