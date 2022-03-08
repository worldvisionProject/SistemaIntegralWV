using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Commands.Update
{
    public class UpdateIndicadorEstrategicoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string IndicadorResultado { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdFactorCritico { get; set; }
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public int Actor { get; set; }
        public int TipoMeta { get; set; }
        public List<IndicadorAF> IndicadorAFs { get; set; }
        public ICollection<IndicadorVinculadoE> IndicadorVinculadoEs { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateIndicadorEstrategicoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoRepository;
            private readonly IIndicadorAFRepository _IndicadorAFRepository;
            private readonly IMapper _mapper;

            public UpdateProductCommandHandler(IIndicadorAFRepository indicadorAFRepository, IIndicadorEstrategicoRepository IndicadorEstrategicoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _IndicadorEstrategicoRepository = IndicadorEstrategicoRepository;
                _IndicadorAFRepository = indicadorAFRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var IndicadorEstrategico = await _IndicadorEstrategicoRepository.GetByIdAsync(command.Id, 0, "");

                if (IndicadorEstrategico == null)
                {
                    return Result<int>.Fail($"IndicadorEstrategico no encontrado.");
                }
                else
                {
                    IndicadorEstrategico.IndicadorResultado = command.IndicadorResultado;
                    IndicadorEstrategico.MedioVerificacion = command.MedioVerificacion;
                    IndicadorEstrategico.Responsable = command.Responsable;
                    IndicadorEstrategico.UnidadMedida = command.UnidadMedida;
                    IndicadorEstrategico.LineaBase = command.LineaBase;
                    IndicadorEstrategico.Meta = command.Meta;
                    IndicadorEstrategico.Codigo = command.Codigo;
                    IndicadorEstrategico.Tipo = command.Tipo;
                    IndicadorEstrategico.Actor = command.Actor; 
                    IndicadorEstrategico.TipoMeta = command.TipoMeta;
                    IndicadorEstrategico.IndicadorVinculadoEs = command.IndicadorVinculadoEs;
                    await _IndicadorEstrategicoRepository.UpdateAsync(IndicadorEstrategico);

                    foreach (var indicador in command.IndicadorAFs)
                    {
                        var indicadorAF = await _IndicadorAFRepository.GetByIdAsync(indicador.Id);
                        if (indicadorAF == null)
                        {
                            var IndicadorAF = _mapper.Map<IndicadorAF>(indicador);
                            IndicadorAF.IdIndicadorEstrategico = IndicadorEstrategico.Id;
                            await _IndicadorAFRepository.InsertAsync(IndicadorAF);
                        }
                        else
                        {
                            indicadorAF.Anio = indicador.Anio;
                            indicadorAF.Meta = indicador.Meta;
                            indicadorAF.Entregable = indicador.Entregable;
                            indicadorAF.LineaBase = indicador.LineaBase;
                         
                            await _IndicadorAFRepository.UpdateAsync(indicadorAF);
                        }


                    }

                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(IndicadorEstrategico.Id);
                }
            }
        }

    }
}
