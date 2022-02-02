using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Commands.Update
{

    public class UpdateIndicadorCicloEstrategicoCommand : IRequest<Result<int>>
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
        //public ICollection<MetaCicloEstrategico> MetaCicloEstrategicos { get; set; }

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
        public class UpdateIndicadorCicloEstrategicoCommandHandler : IRequestHandler<UpdateIndicadorCicloEstrategicoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;
            private readonly IMapper _mapper;

            public UpdateIndicadorCicloEstrategicoCommandHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorCicloEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"IndicadorCicloEstrategico no encontrado.");
                }


                obj.IndicadorCiclo = command.IndicadorCiclo;
                obj.IdEstrategia = command.IdEstrategia;
                obj.AnioFiscal = command.AnioFiscal;
                obj.Meta = command.Meta;
                obj.Logro = command.Logro;
                obj.LineBase = command.LineBase;
                obj.TipoIndicador = command.TipoIndicador;
                obj.CodigoIndicador = command.CodigoIndicador;
                obj.UnidadMedida = command.UnidadMedida;
                obj.ActorParticipante = command.ActorParticipante;
                obj.AnioFiscal2 = command.AnioFiscal2;
                obj.Meta2 = command.Meta2;
                obj.Logro2 = command.Logro2;
                obj.LineBase2 = command.LineBase2;
                obj.AnioFiscal3 = command.AnioFiscal3;
                obj.Meta3 = command.Meta3;
                obj.Logro3 = command.Logro3;
                obj.LineBase3 = command.LineBase3;
                obj.AnioFiscal4 = command.AnioFiscal4;
                obj.Meta4 = command.Meta4;
                obj.Logro4 = command.Logro4;
                obj.LineBase4 = command.LineBase4;
                obj.MetaAcumulada = command.MetaAcumulada;
                await _entidadRepository.UpdateAsync(obj);


                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
