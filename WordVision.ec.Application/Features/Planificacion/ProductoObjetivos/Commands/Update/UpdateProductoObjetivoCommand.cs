using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Commands.Update
{

    public class UpdateProductoObjetivoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int AnioFiscal { get; set; }
        public int IdObjetivoEstra { get; set; }
        public class UpdateProductoObjetivoCommandHandler : IRequestHandler<UpdateProductoObjetivoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProductoObjetivoRepository _entidadRepository;
            private readonly IMapper _mapper;

            public UpdateProductoObjetivoCommandHandler(IProductoObjetivoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateProductoObjetivoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"ProductoObjetivo no encontrado.");
                }


                obj.IdObjetivoEstra = command.IdObjetivoEstra;
                obj.Producto = command.Producto;
                obj.AnioFiscal = command.AnioFiscal;

                await _entidadRepository.UpdateAsync(obj);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
