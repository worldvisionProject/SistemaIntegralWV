using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.OtroIndicador.Commands.Delete
{
    public class DeleteOtroIndicadorCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteOtroIndicadorCommandHandler : IRequestHandler<DeleteOtroIndicadorCommand, Result<int>>
        {
            private readonly IOtroIndicadorRepository _repository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteOtroIndicadorCommandHandler(IOtroIndicadorRepository repository, IUnitOfWork unitOfWork)
            {
                _repository = repository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteOtroIndicadorCommand command, CancellationToken cancellationToken)
            {
                var otroIndicador = await _repository.GetByIdAsync(command.Id);
                try
                {
                    await _repository.DeleteAsync(otroIndicador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(otroIndicador.Id);
                }
                catch (Exception)
                {
                    return Result<int>.Fail($"El OtroIndicador con Código: {otroIndicador.Codigo} no puede ser eliminado porque se encuentra relacionado.");

                }
            }
        }
    }
}
