using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Create
{
  
    public class CreateProductoObjetivoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int IdObjetivoEstra { get; set; }
      
    }

    public class CreateProductoObjetivoCommandHandler : IRequestHandler<CreateProductoObjetivoCommand, Result<int>>
    {
        private readonly IProductoObjetivoRepository _entidadRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProductoObjetivoCommandHandler(IProductoObjetivoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProductoObjetivoCommand request, CancellationToken cancellationToken)
        {
           
                var obj = _mapper.Map<ProductoObjetivo>(request);
                await _entidadRepository.InsertAsync(obj);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
