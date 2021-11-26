using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

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
        public ICollection<FechaCantidadRecurso> FechaCantidadRecursos { get; set; }

        public class UpdateRecursoCommandHandler : IRequestHandler<UpdateRecursoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRecursoRepository _RecursoRepository;
            private readonly IFechaCantidadRecursoRepository _fechaRecursoRepository;
            private readonly IMapper _mapper;

            public UpdateRecursoCommandHandler(IRecursoRepository RecursoRepository, IFechaCantidadRecursoRepository fechaRecursoRepository, IUnitOfWork unitOfWork, IMapper mapper)
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
                    return Result<int>.Fail($"Fecha de recurso no encontrado.");
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
                    recurso.Cantidad = command.Cantidad;
                    recurso.PrecioUnitario = command.PrecioUnitario;
                    recurso.Total = command.Total;
                    recurso.DetalleInsumo = command.DetalleInsumo;
                    recurso.IdActividad = command.IdActividad;

                    await _RecursoRepository.UpdateAsync(recurso);

                    foreach (var fecha in command.FechaCantidadRecursos)
                    {
                        var _fecha = await _fechaRecursoRepository.GetByIdAsync(fecha.Id);
                        if (_fecha == null)
                        {
                            var _fechaEntidad = _mapper.Map<FechaCantidadRecurso>(_fecha);
                            _fechaEntidad.IdRecurso = command.Id;

                            await _fechaRecursoRepository.InsertAsync(_fechaEntidad);
                        }
                        else
                        {
                            _fecha.Mes = fecha.Mes;
                            _fecha.Valor = fecha.Valor;

                            await _fechaRecursoRepository.UpdateAsync(_fecha);
                        }


                    }


                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(recurso.Id);
                }
            }
        }


    }
}
