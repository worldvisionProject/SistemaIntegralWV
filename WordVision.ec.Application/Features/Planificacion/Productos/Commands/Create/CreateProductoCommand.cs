using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Commands.Create
{
  
    public class CreateProductoCommand : IRequest<Result<int>>
    {
      
        public string DescProducto { get; set; }
        public int IdCargoResponsable { get; set; }

        public int IdIndicadorEstrategico { get; set; }
        public int IdGestion { get; set; }
    }

    public class CreateProductoCommandHandler : IRequestHandler<CreateProductoCommand, Result<int>>
    {
        private readonly IProductoRepository _ProductoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProductoCommandHandler(IProductoRepository ProductoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _ProductoRepository = ProductoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
           
                var meta = _mapper.Map<Producto>(request);
                await _ProductoRepository.InsertAsync(meta);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
