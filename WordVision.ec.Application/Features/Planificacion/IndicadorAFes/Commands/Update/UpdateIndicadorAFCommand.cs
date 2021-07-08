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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Commands.Update
{
    public class UpdateIndicadorAFCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public decimal? Meta { get; set; }
        public string Entregable { get; set; }
        public string Anio { get; set; }
        public int IdIndicadorEstrategico { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateIndicadorAFCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorAFRepository _IndicadorAFRepository;

            public UpdateProductCommandHandler(IIndicadorAFRepository IndicadorAFRepository, IUnitOfWork unitOfWork)
            {
                _IndicadorAFRepository = IndicadorAFRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorAFCommand command, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _IndicadorAFRepository.GetByIdAsync(command.Id);

                if (IndicadorAF == null)
                {
                    return Result<int>.Fail($"IndicadorAF no encontrado.");
                }
                else
                {
                    IndicadorAF.Meta = command.Meta;
                    IndicadorAF.Entregable = command.Entregable;
                    IndicadorAF.Anio = command.Anio;

                    await _IndicadorAFRepository.UpdateAsync(IndicadorAF);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(IndicadorAF.Id);
                }
            }
        }

    }
}
