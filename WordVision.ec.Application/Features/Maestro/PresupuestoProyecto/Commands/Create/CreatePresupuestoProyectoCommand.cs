using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;


namespace WordVision.ec.Application.Features.Maestro.PresupuestoProyecto.Commands.Create
{
    public class CreatePresupuestoProyectoCommand : PresupuestoProyectoResponse, IRequest<Result<int>>
    {

    }

    public class CreatePresupuestoCommandCommandHandler : IRequestHandler<CreatePresupuestoProyectoCommand, Result<int>>
    {
        private readonly IPresupuestoProyectoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePresupuestoCommandCommandHandler(IPresupuestoProyectoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePresupuestoProyectoCommand request, CancellationToken cancellationToken)
        {            
            var presupuesto = _mapper.Map<Domain.Entities.Maestro.PresupuestoProyecto>(request);
            if (!await ValidateInsert(presupuesto))
            {
                await _repository.InsertAsync(presupuesto);
                await _unitOfWork.Commit(cancellationToken);
            }
            //else
            //    return Result<int>.Fail($"RC Niño Patrocinado con PA y PT: {request.} o Cédula: {request.Cedula} ya existe.");

            return Result<int>.Success(presupuesto.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.PresupuestoProyecto presupuesto)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(presupuesto);
            if(list.Count> 0)
                exist = true;
            return exist;

        }
    }
}
