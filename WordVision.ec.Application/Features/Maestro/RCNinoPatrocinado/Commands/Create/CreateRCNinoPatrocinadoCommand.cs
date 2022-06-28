using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Commands.Create
{
    public class CreateRCNinoPatrocinadoCommand : RCNinoPatrocinadoResponse, IRequest<Result<int>>
    {

    }

    public class CreateRCNinoPatrocinadoCommandHandler : IRequestHandler<CreateRCNinoPatrocinadoCommand, Result<int>>
    {
        private readonly IRCNinoPatrocinadoRepository _repository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateRCNinoPatrocinadoCommandHandler(IRCNinoPatrocinadoRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateRCNinoPatrocinadoCommand request, CancellationToken cancellationToken)
        {            
            var rCNinoPatrocinado = _mapper.Map<Domain.Entities.Maestro.RCNinoPatrocinado>(request);
            if (!await ValidateInsert(rCNinoPatrocinado))
            {
                await _repository.InsertAsync(rCNinoPatrocinado);
                await _unitOfWork.Commit(cancellationToken);
            }
            else
                return Result<int>.Fail($"RC Niño Patrocinado con Código: {request.Codigo} o Cédula: {request.Cedula} ya existe.");

            return Result<int>.Success(rCNinoPatrocinado.Id);
        }

        private async Task<bool> ValidateInsert(Domain.Entities.Maestro.RCNinoPatrocinado rCNinoPatrocinado)
        {
            bool exist = false;
            var list = await _repository.GetListAsync(rCNinoPatrocinado);
            if(list.Count> 0)
                exist = true;
            return exist;

        }
    }
}
