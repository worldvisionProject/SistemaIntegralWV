using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Soporte;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Commands.Update
{

    public class UpdatePlanificacionResultadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int ReportaId { get; set; }
        public int IdResultado { get; set; }

        public decimal? Meta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Ponderacion { get; set; }
        public string DatoManual1 { get; set; }

        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        public int TipoObjetivo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        public int Estado { get; set; }
        public string ObservacionLider { get; set; }
        //public Resultado Resultados { get; set; }
        public DateTime? FechaCumplimiento { get; set; }
        public decimal? PorcentajeCumplimiento { get; set; }
        public decimal? PonderacionResultado { get; set; }
        public string ComentarioCumplimiento { get; set; }
        public ICollection<AvanceObjetivo> AvanceObjetivos { get; set; }
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
        public ICollection<PlanificacionComportamiento> PlanificacionComportamientos { get; set; }
        public int AnioFiscal { get; set; }
        public int Proceso { get; set; }
        public string ComentarioColaborador { get; set; }
        public string ComentarioLider1 { get; set; }
        public string ComentarioLider2 { get; set; }
        public string ComentarioLiderMatricial { get; set; }
        public decimal? ValorValoracionFinal { get; set; }
        public string ValoracionFinal { get; set; }
        public string ValoracionLider1 { get; set; }
        public class UpdatePlanificacionResultadoCommandHandler : IRequestHandler<UpdatePlanificacionResultadoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPlanificacionResultadoRepository _entidadRepository;
            private readonly ISeguimientoObjetivoRepository _entidadSeguimientoRepository;
            private readonly IPlanificacionHitoRepository _entidadHitoRepository;
            private readonly IPlanificacionComportamientoRepository _entidadComportamientoRepository;

            private readonly IMapper _mapper;

            public UpdatePlanificacionResultadoCommandHandler(IPlanificacionComportamientoRepository entidadComportamientoRepository,IPlanificacionHitoRepository entidadHitoRepository,ISeguimientoObjetivoRepository entidadSeguimientoRepository, IPlanificacionResultadoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _entidadSeguimientoRepository = entidadSeguimientoRepository;
                _entidadHitoRepository = entidadHitoRepository;
                _entidadComportamientoRepository = entidadComportamientoRepository;
                  _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdatePlanificacionResultadoCommand command, CancellationToken cancellationToken)
            {
                

                if (command.Estado!=1)
                {
                    await _entidadRepository.UpdatexColaboradorAsync(command.IdColaborador, command.Estado, command.AnioFiscal);

                    await _entidadSeguimientoRepository.UpdatexTodoAsync(command.IdColaborador, command.AnioFiscal);

                    var seguimiento = new SeguimientoObjetivo();
                    seguimiento.Estado = command.Estado;
                    seguimiento.Ultimo = 1;
                    seguimiento.IdColaborador = command.IdColaborador;
                    seguimiento.AnioFiscal = command.AnioFiscal;
                    if (command.Estado==5 ||  command.Estado == 6)
                    {
                        seguimiento.ComentarioColaborador = command.ComentarioColaborador;
                        seguimiento.ComentarioLider1 = command.ComentarioLider1;
                        seguimiento.ComentarioLider2 = command.ComentarioLider2;
                        seguimiento.ComentarioLiderMatricial = command.ComentarioLiderMatricial;
                        seguimiento.ValoracionFinal = command.ValoracionFinal;
                        seguimiento.ValoracionLider1 = command.ValoracionLider1;
                        seguimiento.ValorValoracionFinal = command.ValorValoracionFinal;

                    }
                    
                    await _entidadSeguimientoRepository.InsertAsync(seguimiento);

                    await _unitOfWork.Commit(cancellationToken);
                 

                }

                var obj = await _entidadRepository.GetByIdAsync(command.Id);

                if (obj == null)
                {
                    return Result<int>.Fail($"PlanificacionResultado no encontrado.");
                }

                //if (command.Resultados.TipoObjetivo == 3)
                //{
                //    var _responsabilidad = await _responsabilidadRepository.GetByIdAsync(command.IdResultado);
                //    var objResponsa = _mapper.Map<Responsabilidad>(_responsabilidad);
                //    obj.Resultados.Nombre = objResponsa.Nombre;
                //    obj.Resultados.Indicador = objResponsa.Indicador;
                //    obj.Resultados.Tipo = objResponsa.Tipo;
                //    obj.Resultados.TipoObjetivo = 2;
                //    obj.Resultados.ObjetivoAnioFiscales = null;
                //}
                //else if (command.Resultados.TipoObjetivo == 4)
                //{
                //    var _competencia = await _competenciaRepository.GetByIdAsync(command.IdResultado);
                //    var objResponsa = _mapper.Map<Competencia>(_competencia);
                //    obj.Resultados.Nombre = objResponsa.NombreCompetencia;
                //    obj.Resultados.Indicador = objResponsa.Comportamiento;
                //    obj.Resultados.Tipo = 0;
                //    obj.Resultados.TipoObjetivo = 3;
                //    obj.Resultados.ObjetivoAnioFiscales = null;
                //}
                //else if (command.Resultados.TipoObjetivo == 5 || command.Resultados.TipoObjetivo == 7)
                //{
                //    var _competencia = await _competenciaRepository.GetByIdAsync(command.IdResultado);
                //    var objResponsa = _mapper.Map<Competencia>(_competencia);
                //    obj.Resultados.Nombre = command.DatoManual1;
                //    obj.Resultados.Indicador = String.Empty;
                //    obj.Resultados.Tipo = 0;
                //    obj.Resultados.TipoObjetivo = 4;
                //    obj.Resultados.ObjetivoAnioFiscales = null;
                //}
                //else if (command.Resultados.TipoObjetivo == 6)
                //{
                //    var _competencia = await _competenciaRepository.GetByIdAsync(command.IdResultado);
                //    var objResponsa = _mapper.Map<Competencia>(_competencia);
                //    obj.Resultados.Nombre = command.DatoManual1;
                //    obj.Resultados.Indicador = command.DatoManual2;
                //    obj.Resultados.Tipo = 0;
                //    obj.Resultados.TipoObjetivo = 4;
                //    obj.Resultados.ObjetivoAnioFiscales = null;
                //}
                //else if (command.Resultados.TipoObjetivo == 1 || command.Resultados.TipoObjetivo == 2)
                //{
                //    obj.Resultados.ObjetivoAnioFiscales = null;
                //    obj.Resultados = null;
                //}
                int idAnioFiscal = command.ObjetivoAnioFiscales.AnioFiscal;
                command.ObjetivoAnioFiscales = null;

                obj.ReportaId = command.ReportaId;
                obj.IdResultado = command.IdResultado;
                obj.Meta = command.Meta;
                obj.FechaInicio = command.FechaInicio;
                obj.FechaFin = command.FechaFin;
                obj.Ponderacion = command.Ponderacion;
                obj.DatoManual1 = command.DatoManual1;
                obj.DatoManual2 = command.DatoManual2;
                obj.DatoManual3 = command.DatoManual3;
                obj.TipoObjetivo = command.TipoObjetivo;
                obj.IdObjetivoAnioFiscal = command.IdObjetivoAnioFiscal;
                //obj.Estado=command.Estado;
                obj.ObservacionLider = command.ObservacionLider;
                obj.FechaCumplimiento = command.FechaCumplimiento;
                obj.PorcentajeCumplimiento=command.PorcentajeCumplimiento;
                obj.PonderacionResultado=command.PonderacionResultado;
                obj.ComentarioCumplimiento=command.ComentarioCumplimiento;

                await _entidadRepository.UpdateAsync(obj);

                foreach (var h in command.PlanificacionHitos)
                {
                   
                    var f=await _entidadHitoRepository.GetByIdAsync(h.Id); 
                    if (f==null)
                    {
                        var hito = _mapper.Map<PlanificacionHito>(h);
                        hito.IdPlanificacion = obj.Id;
                        await _entidadHitoRepository.InsertAsync(hito);
                    }
                    else
                    {
                        f.Nombre = h.Nombre;
                        f.Indicador=h.Indicador;
                        f.Meta = h.Meta;
                        f.FechaInicio = h.FechaInicio;
                        f.FechaFin = h.FechaFin;
                        await _entidadHitoRepository.UpdateAsync(f);
                    
                    }
                    
                }
               

                foreach (var h in command.AvanceObjetivos)
                {
                    var avance = _mapper.Map<AvanceObjetivo>(h);
                     obj.AvanceObjetivos.Add(avance);
                }

                foreach (var h in command.PlanificacionComportamientos)
                {
                    //var comportamiento = _mapper.Map<PlanificacionComportamiento>(h);
                    //obj.PlanificacionComportamientos.Add(comportamiento);

                    var f = await _entidadComportamientoRepository.GetByIdAsync(h.Id);
                    if (f == null)
                    {
                        var comportamiento = _mapper.Map<PlanificacionComportamiento>(h);
                        comportamiento.IdPlanificacion = obj.Id;
                        await _entidadComportamientoRepository.InsertAsync(comportamiento);
                    }
                    else
                    {
                        f.IdCompetencia = h.IdCompetencia;
                        f.FechaFin = h.FechaFin;
                        f.FechaInicio = h.FechaInicio;
                      
                        await _entidadComportamientoRepository.UpdateAsync(f);

                    }

                }

                if (command.Proceso == 1)// para saber si es el final del proceso o se deveolvio
                {
                    await _entidadSeguimientoRepository.UpdatexTodoAsync(command.IdColaborador, idAnioFiscal);

                    var seguimiento = new SeguimientoObjetivo();
                    seguimiento.Estado = command.Estado;
                    seguimiento.Ultimo = 1;
                    seguimiento.IdColaborador = command.IdColaborador;
                    seguimiento.AnioFiscal = idAnioFiscal;
                    await _entidadSeguimientoRepository.InsertAsync(seguimiento);
                }


                


                
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
