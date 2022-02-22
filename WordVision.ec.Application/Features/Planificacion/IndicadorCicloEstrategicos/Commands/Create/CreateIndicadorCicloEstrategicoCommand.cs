using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Create
{

    public class CreateIndicadorCicloEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string IndicadorCiclo { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public decimal? LineBase { get; set; }
        public int AnioFiscal { get; set; }
        public int IdEstrategia { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public int ActorParticipante { get; set; }
        public int AnioFiscal2 { get; set; }
        public decimal? Meta2 { get; set; }
        public decimal? Logro2 { get; set; }
        public decimal? LineBase2 { get; set; }

        public int AnioFiscal3 { get; set; }
        public decimal? Meta3 { get; set; }
        public decimal? Logro3 { get; set; }
        public decimal? LineBase3 { get; set; }

        public int AnioFiscal4 { get; set; }
        public decimal? Meta4 { get; set; }
        public decimal? Logro4 { get; set; }
        public decimal? LineBase4 { get; set; }
        public decimal? MetaAcumulada { get; set; }
        public int TipoMeta { get; set; }
        //public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }
    }

    public class CreateIndicadorCicloEstrategicoCommandHandler : IRequestHandler<CreateIndicadorCicloEstrategicoCommand, Result<int>>
    {
        private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateIndicadorCicloEstrategicoCommandHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateIndicadorCicloEstrategicoCommand request, CancellationToken cancellationToken)
        {

            var obj = _mapper.Map<IndicadorCicloEstrategico>(request);
            await _entidadRepository.InsertAsync(obj);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success();
        }
    }
}
