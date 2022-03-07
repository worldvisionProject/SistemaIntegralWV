using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Create
{

    public partial class CreateIndicadorPOACommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string IndicadorProducto { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int TipoMeta { get; set; }
        public int IdProducto { get; set; }
        public Producto Productos { get; set; }
        public ICollection<Actividad> Actividades { get; set; }
        public ICollection<MetaTactica> MetaTacticas { get; set; }


    }

    public class CreateIndicadorPOACommandHandler : IRequestHandler<CreateIndicadorPOACommand, Result<int>>
    {
        private readonly IIndicadorPOARepository _IndicadorPOARepository;
        private readonly IMetaTacticaRepository _metaTacticaRepository;
        private readonly IActividadRepository _actividadRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorPOACommandHandler(IActividadRepository actividadRepository, IMetaTacticaRepository metaTacticaRepository, IIndicadorPOARepository IndicadorPOARepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _IndicadorPOARepository = IndicadorPOARepository;
            _metaTacticaRepository = metaTacticaRepository;
            _actividadRepository = actividadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorPOACommand request, CancellationToken cancellationToken)
        {
            var IndicadorPOA = _mapper.Map<IndicadorPOA>(request);
            await _IndicadorPOARepository.InsertAsync(IndicadorPOA);

            foreach (var m in request.MetaTacticas)
            {
                var meta = _mapper.Map<MetaTactica>(m);
                meta.IdIndicadorPOA = IndicadorPOA.Id;
                await _metaTacticaRepository.InsertAsync(meta);
            }

            foreach (var a in request.Actividades)
            {
                var actividad = _mapper.Map<Actividad>(a);
                actividad.IdIndicadorPOA = IndicadorPOA.Id;
                await _actividadRepository.InsertAsync(actividad);
            }

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(IndicadorPOA.Id);
        }
    }
}
