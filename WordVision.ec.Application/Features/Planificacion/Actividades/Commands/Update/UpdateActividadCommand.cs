using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Commands.Update
{
    public class UpdateActividadCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string DescripcionActividad { get; set; }
        public string Entregable { get; set; }
        public int IdCargoResponsable { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal? Ponderacion { get; set; }
        public string SNPresupuesto { get; set; }
        public decimal? TechoPresupuestoCC { get; set; }
        public decimal? TotalRecurso { get; set; }
        public decimal? Saldo { get; set; }

        public int IdIndicadorPOA { get; set; }
        public ICollection<Recurso> Recursos { get; set; }
        public ICollection<FechaCantidadRecurso> fechaCantidadRecursos { get; set; }
        public class UpdateActividadCommandHandler : IRequestHandler<UpdateActividadCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IRecursoRepository _RecursoRepository;
            private readonly IFechaCantidadRecursoRepository _fechaRecursoRepository;
            private readonly IActividadRepository _actividadRepository;
            private readonly IMapper _mapper;

            public UpdateActividadCommandHandler(IActividadRepository actividadRepository, IFechaCantidadRecursoRepository fechaRecursoRepository, IRecursoRepository RecursoRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _RecursoRepository = RecursoRepository;
                _fechaRecursoRepository = fechaRecursoRepository;
                _actividadRepository = actividadRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateActividadCommand command, CancellationToken cancellationToken)
            {
                var actividad = await _actividadRepository.GetByIdAsync(command.Id);

                if (actividad == null)
                {
                    return Result<int>.Fail($"Actividad no encontrado.");
                }
                else
                {
                    actividad.DescripcionActividad = command.DescripcionActividad ?? actividad.DescripcionActividad;
                    actividad.Entregable = command.Entregable ?? actividad.Entregable;
                    actividad.IdCargoResponsable = command.IdCargoResponsable == 0 ? actividad.IdCargoResponsable : command.IdCargoResponsable;
                    actividad.FechaInicio = command.FechaInicio;
                    actividad.FechaFin = command.FechaFin;
                    actividad.Ponderacion = command.Ponderacion ?? actividad.Ponderacion;
                    actividad.SNPresupuesto = command.SNPresupuesto ?? actividad.SNPresupuesto;
                    actividad.TechoPresupuestoCC = command.TechoPresupuestoCC ?? actividad.TechoPresupuestoCC;
                    actividad.TotalRecurso = command.TotalRecurso ?? actividad.TotalRecurso;
                    actividad.Saldo = command.Saldo ?? actividad.Saldo;
                    actividad.IdIndicadorPOA = command.IdIndicadorPOA == 0 ? actividad.IdIndicadorPOA : command.IdIndicadorPOA;

                    await _actividadRepository.UpdateAsync(actividad);

                    foreach (var m in command.Recursos)
                    {
                        var _recurso = await _RecursoRepository.GetByIdAsync(m.Id);
                        if (_recurso == null)
                        {
                            var recurso = _mapper.Map<Recurso>(m);
                            recurso.IdActividad = actividad.Id;
                            await _RecursoRepository.InsertAsync(recurso);
                        }
                        else
                        {
                            _recurso.Insumo = m.Insumo;
                            _recurso.CategoriaMercaderia = m.CategoriaMercaderia;
                            _recurso.CentroCosto = m.CentroCosto;
                            _recurso.CuentaCodigoCC = m.CuentaCodigoCC;
                            _recurso.ParaqueConsultoria = m.ParaqueConsultoria ?? _recurso.ParaqueConsultoria;
                            _recurso.Gtrm = m.Gtrm ?? _recurso.Gtrm;
                            _recurso.JustificacionConsultoria = m.JustificacionConsultoria ?? _recurso.JustificacionConsultoria;
                            _recurso.Cantidad = m.Cantidad;
                            _recurso.PrecioUnitario = m.PrecioUnitario;
                            _recurso.Total = m.Total;
                            await _RecursoRepository.UpdateAsync(_recurso);
                        }


                        foreach (var a in m.FechaCantidadRecursos)
                        {

                            var cantidad = await _fechaRecursoRepository.GetByIdAsync(a.Id);
                            if (cantidad == null)
                            {
                                var cant = _mapper.Map<FechaCantidadRecurso>(a);
                                cant.IdRecurso = _recurso.Id;
                                await _fechaRecursoRepository.InsertAsync(cant);
                            }
                            else
                            {
                                cantidad.Mes = a.Mes == 0 ? cantidad.Mes : a.Mes;
                                cantidad.Valor = a.Valor == 0 ? cantidad.Valor : a.Valor;


                                await _fechaRecursoRepository.UpdateAsync(cantidad);
                            }
                        }

                    }





                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(actividad.Id);
                }
            }
        }


    }
}
