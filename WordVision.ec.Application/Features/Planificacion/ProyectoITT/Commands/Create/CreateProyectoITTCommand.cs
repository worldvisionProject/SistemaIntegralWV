using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.ProyectoITT.Commands.Create
{
    public class CreateProyectoITTCommand : ProyectoITTResponse, IRequest<Result<int>>
    {
    }

    public class CreateProyectoITTCommandHandler : IRequestHandler<CreateProyectoITTCommand, Result<int>>
    {
        private readonly IProyectoITTRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProyectoITTCommandHandler(IProyectoITTRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProyectoITTCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Planificacion.ProyectoITT>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
