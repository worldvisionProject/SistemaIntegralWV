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

namespace WordVision.ec.Application.Features.Planificacion.Productos.Commands.Delete
{
    public class DeleteProductoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteProductoCommandHandler : IRequestHandler<DeleteProductoCommand, Result<int>>
        {
            private readonly IProductoRepository _ProductoRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteProductoCommandHandler(IProductoRepository ProductoRepository, IUnitOfWork unitOfWork)
            {
                _ProductoRepository = ProductoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteProductoCommand command, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _ProductoRepository.GetByIdAsync(command.Id);
                await _ProductoRepository.DeleteAsync(IndicadorAF);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(IndicadorAF.Id);
            }
        }

    }
}
