using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Update
{
    public class UpdateFactorCriticoExitoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string FactorCritico { get; set; }

        public int IdObjetivoEstra { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateFactorCriticoExitoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IFactorCriticoExitoRepository _FactorCriticoExitoRepository;

            public UpdateProductCommandHandler(IFactorCriticoExitoRepository FactorCriticoExitoRepository, IUnitOfWork unitOfWork)
            {
                _FactorCriticoExitoRepository = FactorCriticoExitoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateFactorCriticoExitoCommand command, CancellationToken cancellationToken)
            {
                var FactorCriticoExito = await _FactorCriticoExitoRepository.GetByIdAsync(command.Id);

                if (FactorCriticoExito == null)
                {
                    return Result<int>.Fail($"FactorCriticoExito no encontrado.");
                }
                else
                {
                    FactorCriticoExito.Id = command.Id;
                    FactorCriticoExito.FactorCritico = command.FactorCritico;
                    FactorCriticoExito.IdObjetivoEstra = command.IdObjetivoEstra;
                    await _FactorCriticoExitoRepository.UpdateAsync(FactorCriticoExito);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(FactorCriticoExito.Id);
                }
            }
        }

    }
}
