using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Presupuesto.DatosLDR.Commands.Update
{
    public class UpdateDatosLDRCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Ubicacion { get; set; }
        public string T0 { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string FijoEventual { get; set; }
        public decimal Ldr { get; set; }
        public decimal TotalGasto { get; set; }
        public decimal PorceImputado { get; set; }
        public decimal ValorImputado { get; set; }
        public class UpdateDatosLDRCommandHandler : IRequestHandler<UpdateDatosLDRCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IDatosLDRRepository _datosLDRRepository;

            public UpdateDatosLDRCommandHandler(IDatosLDRRepository datosLDRRepository, IUnitOfWork unitOfWork)
            {
                _datosLDRRepository = datosLDRRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(UpdateDatosLDRCommand command, CancellationToken cancellationToken)
            {
                var colaborador = await _datosLDRRepository.GetByIdAsync(command.Id);

                if (colaborador == null)
                {
                    return Result<int>.Fail($"LDR no encontrado.");
                }
                else
                {
                    colaborador.Identificacion = command.Identificacion ?? colaborador.Identificacion;
                    colaborador.Ubicacion = command.Ubicacion ?? colaborador.Ubicacion;
                    colaborador.T0 = command.T0 ?? colaborador.T0;
                    colaborador.T1 = command.T1 ?? colaborador.T1;
                    colaborador.T2 = command.T2 ?? colaborador.T2;
                    colaborador.T3 = command.T3 ?? colaborador.T3;
                    colaborador.T4 = command.T4 ?? colaborador.T4;
                    colaborador.T5 = command.T5 ?? colaborador.T5;
                    colaborador.T6 = command.T6 ?? colaborador.T6;
                    colaborador.T7 = command.T7 ?? colaborador.T7;
                    colaborador.T8 = command.T8 ?? colaborador.T8;
                    colaborador.T9 = command.T9 ?? colaborador.T9;
                    colaborador.FijoEventual = command.FijoEventual ?? colaborador.FijoEventual;
                    colaborador.Ldr = command.Ldr==0? colaborador.Ldr: command.Ldr;
                    colaborador.TotalGasto = command.TotalGasto == 0 ? colaborador.TotalGasto: command.TotalGasto;
                    colaborador.PorceImputado = command.PorceImputado == 0 ? colaborador.PorceImputado: command.PorceImputado;
                    colaborador.ValorImputado = command.ValorImputado == 0 ? colaborador.ValorImputado: command.ValorImputado;

                    await _datosLDRRepository.UpdateAsync(colaborador);
                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(colaborador.Id);
                }
            }
        }
    }
}
