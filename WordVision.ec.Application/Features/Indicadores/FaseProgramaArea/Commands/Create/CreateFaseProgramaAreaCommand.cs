using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Commands.Create
{
    public class CreateFaseProgramaAreaCommand : FaseProgramaAreaResponse, IRequest<Result<int>>
    {
    }

    public class CreateFaseProgramaAreaCommandHandler : IRequestHandler<CreateFaseProgramaAreaCommand, Result<int>>
    {
        private readonly IFaseProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateFaseProgramaAreaCommandHandler(IFaseProgramaAreaRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateFaseProgramaAreaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.FaseProgramaArea>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
