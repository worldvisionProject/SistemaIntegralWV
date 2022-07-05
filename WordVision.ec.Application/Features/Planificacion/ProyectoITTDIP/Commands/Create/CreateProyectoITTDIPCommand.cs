using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITTDIP.Commands.Create
{
    public class CreateProyectoITTDIPCommand : ProyectoITTDIPResponse, IRequest<Result<int>>
    {
    }

    public class CreateProyectoITTDIPCommandHandler : IRequestHandler<CreateProyectoITTDIPCommand, Result<int>>
    {
        private readonly IProyectoITTDIPRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateProyectoITTDIPCommandHandler(IProyectoITTDIPRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateProyectoITTDIPCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Planificacion.ProyectoITTDIP>(request);
            await _repository.InsertAsync(entity);
            await _unitOfWork.Commit(cancellationToken);

            return Result<int>.Success(entity.Id);
        }
    }
}
