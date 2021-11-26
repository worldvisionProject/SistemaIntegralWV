using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.TechoPresupuestarios.Commands.Create
{
    public class CreateTechoPresupuestarioCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string CodigoCC { get; set; }
        public string DescripcionCC { get; set; }
        public decimal? Techo { get; set; }
    }

    public class CreateTechoPresupuestarioCommandHandler : IRequestHandler<CreateTechoPresupuestarioCommand, Result<int>>
    {
        private readonly ITechoPresupuestarioRepository _TechoPresupuestarioRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateTechoPresupuestarioCommandHandler(ITechoPresupuestarioRepository TechoPresupuestarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _TechoPresupuestarioRepository = TechoPresupuestarioRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTechoPresupuestarioCommand request, CancellationToken cancellationToken)
        {


            var meta = _mapper.Map<TechoPresupuestario>(request);
            await _TechoPresupuestarioRepository.InsertAsync(meta);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
