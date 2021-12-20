using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Commands.Update
{

    public class UpdateIndicadorProductoObjetivoCommand : IRequest<Result<int>>
    {

        public int Id { get; set; }
        public string Indicador { get; set; }
        public decimal? Meta { get; set; }
        public decimal? Logro { get; set; }
        public int AnioFiscal { get; set; }
        public int IdProductoObjetivo { get; set; }
        public int TipoIndicador { get; set; }
        public int CodigoIndicador { get; set; }
        public int UnidadMedida { get; set; }
        public string ActorParticipante { get; set; }
        public ProductoObjetivo ProductoObjetivos { get; set; }
        public class UpdateIndicadorProductoObjetivoCommandHandler : IRequestHandler<UpdateIndicadorProductoObjetivoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorProductoObjetivoRepository _entidadRepository;
            private readonly IMapper _mapper;

            public UpdateIndicadorProductoObjetivoCommandHandler(IIndicadorProductoObjetivoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorProductoObjetivoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"IndicadorProductoObjetivo no encontrado.");
                }


                obj.Indicador = command.Indicador;
                obj.AnioFiscal = command.AnioFiscal;
                obj.IdProductoObjetivo = command.IdProductoObjetivo; 
                obj.TipoIndicador = command.TipoIndicador;
                obj.CodigoIndicador = command.CodigoIndicador;
                obj.UnidadMedida = command.UnidadMedida;
                obj.ActorParticipante = command.ActorParticipante;

                await _entidadRepository.UpdateAsync(obj);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
