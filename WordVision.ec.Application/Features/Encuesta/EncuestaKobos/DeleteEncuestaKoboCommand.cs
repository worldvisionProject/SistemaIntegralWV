using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{
    public class DeleteEncuestaKoboCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteEncuestaKoboCommandHandler : IRequestHandler<DeleteEncuestaKoboCommand, Result<int>>
        {
            private readonly IEncuestaKoboRepository _encuestaKoboRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteEncuestaKoboCommandHandler(IEncuestaKoboRepository encuestaKoboRepository, IUnitOfWork unitOfWork)
            {
                _encuestaKoboRepository = encuestaKoboRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteEncuestaKoboCommand command, CancellationToken cancellationToken)
            {
                var EncuestaKobo = await _encuestaKoboRepository.GetByIdAsync(command.Id);
                await _encuestaKoboRepository.DeleteAsync(EncuestaKobo);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(EncuestaKobo.Id);
            }
        }

    }
}
