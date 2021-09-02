using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Delete
{
    public class DeleteProductoObjetivoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteProductoObjetivoCommandHandler : IRequestHandler<DeleteProductoObjetivoCommand, Result<int>>
        {
            private readonly IProductoObjetivoRepository _entidadRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteProductoObjetivoCommandHandler(IProductoObjetivoRepository entidadRepository, IUnitOfWork unitOfWork)
            {
                _entidadRepository = entidadRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteProductoObjetivoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);
                await _entidadRepository.DeleteAsync(obj);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);
            }
        }

    }
}
