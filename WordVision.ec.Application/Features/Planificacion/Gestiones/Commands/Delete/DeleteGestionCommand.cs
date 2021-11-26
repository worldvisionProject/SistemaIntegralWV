using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Delete
{
    public class DeleteGestionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteGestionCommandHandler : IRequestHandler<DeleteGestionCommand, Result<int>>
        {
            private readonly IGestionRepository _GestionRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteGestionCommandHandler(IGestionRepository GestionRepository, IUnitOfWork unitOfWork)
            {
                _GestionRepository = GestionRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteGestionCommand command, CancellationToken cancellationToken)
            {
                var Gestion = await _GestionRepository.GetByIdAsync(command.Id);
                await _GestionRepository.DeleteAsync(Gestion);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Gestion.Id);
            }
        }

    }
}
