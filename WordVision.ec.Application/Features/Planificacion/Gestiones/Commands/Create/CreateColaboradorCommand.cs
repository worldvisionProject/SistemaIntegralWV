using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Commands.Create
{

    public partial class CreateGestionCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }

        public string Estado { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public int IdEstrategia { get; set; }

    }

    public class CreateGestionCommandHandler : IRequestHandler<CreateGestionCommand, Result<int>>
    {
        private readonly IGestionRepository _GestionRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateGestionCommandHandler(IGestionRepository GestionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _GestionRepository = GestionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateGestionCommand request, CancellationToken cancellationToken)
        {
            var Gestion = _mapper.Map<Gestion>(request);
            await _GestionRepository.InsertAsync(Gestion);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(Gestion.Id);
        }
    }
}
