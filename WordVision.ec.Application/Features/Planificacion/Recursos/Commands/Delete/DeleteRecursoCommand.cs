using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Delete
{
    public class DeleteRecursoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteRecursoCommandHandler : IRequestHandler<DeleteRecursoCommand, Result<int>>
        {
            private readonly IRecursoRepository _RecursoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteRecursoCommandHandler(IRecursoRepository RecursoRepository, IUnitOfWork unitOfWork)
            {
                _RecursoRepository = RecursoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteRecursoCommand command, CancellationToken cancellationToken)
            {
                var Recurso = await _RecursoRepository.GetByIdAsync(command.Id);
                await _RecursoRepository.DeleteAsync(Recurso);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Recurso.Id);
            }
        }
    }
}
