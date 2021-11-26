using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Seguimientos.Commands.Create
{
    public class CreateSeguimientoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdIndicador { get; set; }
        public string Tipo { get; set; }
        public int Mes { get; set; }
        public string Avance { get; set; }
        public decimal? PorcentajeAvance { get; set; }
        public string RutaAdjunto { get; set; }

        public string NombreAdjunto { get; set; }
        public string AvanceCompetencia { get; set; }
    }

    public class CreateSeguimientoCommandHandler : IRequestHandler<CreateSeguimientoCommand, Result<int>>
    {
        private readonly ISeguimientoRepository _SeguimientoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateSeguimientoCommandHandler(ISeguimientoRepository SeguimientoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _SeguimientoRepository = SeguimientoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateSeguimientoCommand request, CancellationToken cancellationToken)
        {


            var meta = _mapper.Map<Seguimiento>(request);
            await _SeguimientoRepository.InsertAsync(meta);

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
