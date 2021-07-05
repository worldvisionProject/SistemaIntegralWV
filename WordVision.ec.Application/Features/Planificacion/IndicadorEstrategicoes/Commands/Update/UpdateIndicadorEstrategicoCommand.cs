using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

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
        public class UpdateProductCommandHandler : IRequestHandler<UpdateIndicadorEstrategicoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoRepository;

            public UpdateProductCommandHandler(IIndicadorEstrategicoRepository IndicadorEstrategicoRepository, IUnitOfWork unitOfWork)
            {
                _IndicadorEstrategicoRepository = IndicadorEstrategicoRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorEstrategicoCommand command, CancellationToken cancellationToken)
            {
                var IndicadorEstrategico = await _IndicadorEstrategicoRepository.GetByIdAsync(command.Id);

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


                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(IndicadorEstrategico.Id);
                }
            }
        }

    }
}
