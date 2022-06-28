using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Create
{

    public partial class CreateIndicadorEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int TipoMeta { get; set; }
        public int IdFactorCritico { get; set; }
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public int Actor { get; set; }
        public int? Seleccionado { get; set; }
        public List<IndicadorAF> IndicadorAFs { get; set; }
        public ICollection<IndicadorVinculadoE> IndicadorVinculadoEs { get; set; }
    }

    public class CreateIndicadorEstrategicoCommandHandler : IRequestHandler<CreateIndicadorEstrategicoCommand, Result<int>>
    {
        private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoRepository;
        private readonly IIndicadorAFRepository _IndicadorAFRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorEstrategicoCommandHandler(IIndicadorAFRepository indicadorAFRepository, IIndicadorEstrategicoRepository IndicadorEstrategicoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _IndicadorEstrategicoRepository = IndicadorEstrategicoRepository;
            _IndicadorAFRepository = indicadorAFRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorEstrategicoCommand request, CancellationToken cancellationToken)
        {
            var IndicadorEstrategico = _mapper.Map<IndicadorEstrategico>(request);
            await _IndicadorEstrategicoRepository.InsertAsync(IndicadorEstrategico);

            foreach (var indicador in request.IndicadorAFs)
            {
                var IndicadorAF = _mapper.Map<IndicadorAF>(indicador);
                IndicadorAF.IdIndicadorEstrategico = IndicadorEstrategico.Id;
                await _IndicadorAFRepository.InsertAsync(IndicadorAF);
            }

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(IndicadorEstrategico.Id);
        }
    }
}
