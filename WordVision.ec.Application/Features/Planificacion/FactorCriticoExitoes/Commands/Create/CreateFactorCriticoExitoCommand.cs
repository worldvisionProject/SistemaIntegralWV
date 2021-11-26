using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Commands.Create
{

    public partial class CreateFactorCriticoExitoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string FactorCritico { get; set; }

        public int IdObjetivoEstra { get; set; }

    }

    public class CreateFactorCriticoExitoCommandHandler : IRequestHandler<CreateFactorCriticoExitoCommand, Result<int>>
    {
        private readonly IFactorCriticoExitoRepository _FactorCriticoExitoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateFactorCriticoExitoCommandHandler(IFactorCriticoExitoRepository FactorCriticoExitoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _FactorCriticoExitoRepository = FactorCriticoExitoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateFactorCriticoExitoCommand request, CancellationToken cancellationToken)
        {
            var FactorCriticoExito = _mapper.Map<FactorCriticoExito>(request);
            await _FactorCriticoExitoRepository.InsertAsync(FactorCriticoExito);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(FactorCriticoExito.Id);
        }
    }
}
