using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Commands.Update
{
    public class UpdateVinculacionIndicadorCommand : VinculacionIndicadorResponse, IRequest<Result<int>>
    {
    }

    public class UpdateVinculacionIndicadorCommandHandler : IRequestHandler<UpdateVinculacionIndicadorCommand, Result<int>>
    {
        private readonly IVinculacionIndicadorRepository _repository;

        private IUnitOfWork _unitOfWork { get; set; }

        public UpdateVinculacionIndicadorCommandHandler(IVinculacionIndicadorRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateVinculacionIndicadorCommand update, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(update.Id);

            if (entity == null)
            {
                return Result<int>.Fail($"VinculacionIndicador no encontrada.");
            }
            else
            {
                entity.Riesgos = update.Riesgos;
                entity.PlanNacionalDesarrollo = update.PlanNacionalDesarrollo;
                entity.IdIndicadorPR = update.IdIndicadorPR;
                entity.IdOtroIndicador = update.IdOtroIndicador;
                entity.IdEstado = update.IdEstado;

                await _repository.UpdateAsync(entity);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(entity.Id);
            }
        }
    }
}
