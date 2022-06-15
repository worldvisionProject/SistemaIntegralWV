using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Update
{
    public class UpdateEstadoPorAnioFiscalCommand : EstadoPorAnioFiscalResponse, IRequest<Result<int>>
    {
    }

    public class UpdateEstadoPorAnioFiscalCommandHandler : IRequestHandler<UpdateEstadoPorAnioFiscalCommand, Result<int>>
    {
        private readonly IEstadoPorAnioFiscalRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateEstadoPorAnioFiscalCommandHandler(IEstadoPorAnioFiscalRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateEstadoPorAnioFiscalCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"EstadoPorAnioFiscal no encontrada.");
            }
            else
            {
                entity.AnioFiscal = update.AnioFiscal;               
                entity.FechaInicio = update.FechaInicio;
                entity.FechaFin = update.FechaFin;
                entity.IdProceso = update.IdProceso;
                entity.IdEstadoAnioFiscal = update.IdEstadoAnioFiscal;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
