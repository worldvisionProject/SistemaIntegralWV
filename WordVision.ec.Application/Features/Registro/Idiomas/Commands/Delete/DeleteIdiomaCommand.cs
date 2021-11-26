using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Idiomas.Commands.Delete
{
    public class DeleteIdiomaCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteIdiomaCommandHandler : IRequestHandler<DeleteIdiomaCommand, Result<int>>
        {
            private readonly IIdiomaRepository _idiomaRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteIdiomaCommandHandler(IIdiomaRepository idiomaRepository, IUnitOfWork unitOfWork)
            {
                _idiomaRepository = idiomaRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteIdiomaCommand command, CancellationToken cancellationToken)
            {
                var idioma = await _idiomaRepository.GetByIdAsync(command.Id);
                await _idiomaRepository.DeleteAsync(idioma);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(idioma.Id);
            }
        }
    }
}
