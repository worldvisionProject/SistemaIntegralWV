using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Commands.Update
{

    public class UpdateProductoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string DescProducto { get; set; }
        public int IdCargoResponsable { get; set; }

        public int IdIndicadorEstrategico { get; set; }
        public int IdGestion { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProductoRepository _ProductoRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IProductoRepository ProductoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _ProductoRepository = ProductoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateProductoCommand command, CancellationToken cancellationToken)
            {
                var producto = await _ProductoRepository.GetByIdAsync(command.Id, 0, "");

                if (producto == null)
                {
                    return Result<int>.Fail($"producto no encontrado.");
                }



                producto.IdIndicadorEstrategico = command.IdIndicadorEstrategico;
                producto.IdGestion = command.IdGestion;
                producto.DescProducto = command.DescProducto;
                producto.IdCargoResponsable = command.IdCargoResponsable;

                await _ProductoRepository.UpdateAsync(producto);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(producto.Id);

            }
        }

    }
}
