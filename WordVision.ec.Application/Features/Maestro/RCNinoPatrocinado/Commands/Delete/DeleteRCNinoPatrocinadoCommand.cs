using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Delete
{
    public class DeleteRCNinoPatrocinadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteRCNinoPatrocinadoCommandHandler : IRequestHandler<DeleteRCNinoPatrocinadoCommand, Result<int>>
        {
            private readonly IRCNinoPatrocinadoRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteRCNinoPatrocinadoCommandHandler(IRCNinoPatrocinadoRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteRCNinoPatrocinadoCommand command, CancellationToken cancellationToken)
            {
                var rcNinoPatrocinado = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(rcNinoPatrocinado);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(rcNinoPatrocinado.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El RCNinoPatrocinado con Código: {rcNinoPatrocinado.Codigo} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
