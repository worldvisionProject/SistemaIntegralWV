using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Recursos.Commands.Update
{
    public class UpdateRecursoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int CentroCosto { get; set; }
        public int CuentaCodigoCC { get; set; }
        public int CategoriaMercaderia { get; set; }
        public int Insumo { get; set; }
        public string ParaqueConsultoria { get; set; }
        public string Gtrm { get; set; }
        public string JustificacionConsultoria { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Total { get; set; }
        public string DetalleInsumo { get; set; }
        public int IdActividad { get; set; }


        public class UpdateRecursoCommandHandler : IRequestHandler<UpdateRecursoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRecursoRepository _RecursoRepository;
            private readonly IFechaCantidadRecursoRepository _fechaRecursoRepository;
            private readonly IMapper _mapper;

            public UpdateRecursoCommandHandler(IRecursoRepository RecursoRepository, IFechaCantidadRecursoRepository fechaRecursoRepository,  IUnitOfWork unitOfWork, IMapper mapper)
            {
                _fechaRecursoRepository = fechaRecursoRepository;
                _RecursoRepository = RecursoRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateRecursoCommand command, CancellationToken cancellationToken)
            {
                var recurso = await _RecursoRepository.GetByIdAsync(command.Id);

                if (recurso == null)
                {
                    return Result<int>.Fail($"Recurso no encontrado.");
                }
                else
                {
                    recurso.CentroCosto = command.CentroCosto;
                    recurso.CuentaCodigoCC = command.CuentaCodigoCC;
                    recurso.CategoriaMercaderia = command.CategoriaMercaderia;
                    recurso.Insumo = command.Insumo;
                    recurso.ParaqueConsultoria = command.ParaqueConsultoria;
                    recurso.Gtrm = command.Gtrm;
                    recurso.JustificacionConsultoria = command.JustificacionConsultoria;
                    recurso.Cantidad = command.Cantidad ;
                    recurso.PrecioUnitario = command.PrecioUnitario;
                    recurso.Total = command.Total;
                    recurso.DetalleInsumo = command.DetalleInsumo;
                    recurso.IdActividad = command.IdActividad;


                    await _RecursoRepository.UpdateAsync(recurso);

                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(recurso.Id);
                }
            }
        }


    }
}
