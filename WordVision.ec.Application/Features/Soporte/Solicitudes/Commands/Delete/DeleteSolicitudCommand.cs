using AspNetCoreHero.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Planificacion.MetaTacticas.Commands.Delete
{

    public class DeleteSolicitudCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteSolicitudCommandHandler : IRequestHandler<DeleteSolicitudCommand, Result<int>>
        {
            private readonly ISolicitudRepository _SolicitudRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteSolicitudCommandHandler(ISolicitudRepository SolicitudRepository, IUnitOfWork unitOfWork)
            {
                _SolicitudRepository = SolicitudRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteSolicitudCommand command, CancellationToken cancellationToken)
            {
                var solicitud = await _SolicitudRepository.GetByIdAsync(command.Id);
                await _SolicitudRepository.DeleteAsync(solicitud);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(solicitud.Id);
            }
        }
    }
}
