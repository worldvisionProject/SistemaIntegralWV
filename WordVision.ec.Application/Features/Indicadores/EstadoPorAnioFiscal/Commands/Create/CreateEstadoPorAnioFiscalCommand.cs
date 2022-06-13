using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Commands.Create
{
    public class CreateEstadoPorAnioFiscalCommand : EstadoPorAnioFiscalResponse, IRequest<Result<int>>
    {
    }

    public class CreateEstadoPorAnioFiscalCommandHandler : IRequestHandler<CreateEstadoPorAnioFiscalCommand, Result<int>>
    {
        private readonly IEstadoPorAnioFiscalRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateEstadoPorAnioFiscalCommandHandler(IEstadoPorAnioFiscalRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateEstadoPorAnioFiscalCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.EstadoPorAnioFiscal>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
