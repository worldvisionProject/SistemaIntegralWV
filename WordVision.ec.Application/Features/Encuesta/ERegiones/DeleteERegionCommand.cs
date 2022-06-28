using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
namespace WordVision.ec.Application.Features.Encuesta.ERegiones
{
    public class DeleteERegionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteERegionCommandHandler : IRequestHandler<DeleteERegionCommand, Result<int>>
        {
            private readonly IERegionRepository _eRegionRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteERegionCommandHandler(IERegionRepository eRegionRepository, IUnitOfWork unitOfWork)
            {
                _eRegionRepository = eRegionRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteERegionCommand request, CancellationToken cancellationToken)
            {
                var ERegion = await _eRegionRepository.GetByIdAsync(request.Id);

                if (ERegion == null)
                {
                    return Result<int>.Fail($"Registro no encontrado con el Id " + request.Id);
                }
                else
                {
                    //Eliminamos el registro en la base de datos
                    await _eRegionRepository.DeleteAsync(ERegion);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(ERegion.Id);
                }

            }
        }

    }
}
