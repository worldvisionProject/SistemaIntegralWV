using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Delete
{
   
    public class DeleteActividadCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteActividadCommandHandler : IRequestHandler<DeleteActividadCommand, Result<int>>
        {
            private readonly IActividadRepository _ActividadRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteActividadCommandHandler(IActividadRepository ActividadRepository, IUnitOfWork unitOfWork)
            {
                _ActividadRepository = ActividadRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteActividadCommand command, CancellationToken cancellationToken)
            {
                var Actividad = await _ActividadRepository.GetByIdAsync(command.Id);
                await _ActividadRepository.DeleteAsync(Actividad);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Actividad.Id);
            }
        }
    }

}
