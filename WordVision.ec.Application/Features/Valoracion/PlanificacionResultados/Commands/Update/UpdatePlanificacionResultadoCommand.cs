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
        public int Estado { get; set; }
        public string ObservacionLider { get; set; }
        //public Resultado Resultados { get; set; }
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
        public class UpdatePlanificacionResultadoCommandHandler : IRequestHandler<UpdatePlanificacionResultadoCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPlanificacionResultadoRepository _entidadRepository;
            private readonly IPlanificacionHitoRepository _entidadHitoRepository;
            private readonly IResponsabilidadRepository _responsabilidadRepository;
            private readonly ICompetenciaRepository _competenciaRepository;
            private readonly IMapper _mapper;

            public UpdatePlanificacionResultadoCommandHandler(IPlanificacionHitoRepository entidadHitoRepository, ICompetenciaRepository competenciaRepository,  IResponsabilidadRepository responsabilidadRepository, IPlanificacionResultadoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _entidadHitoRepository = entidadHitoRepository;
                _responsabilidadRepository = responsabilidadRepository;
                _competenciaRepository = competenciaRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdatePlanificacionResultadoCommand command, CancellationToken cancellationToken)
            {
                if (command.Estado==2 || command.Estado == 3 || command.Estado == 4)
                {
                    await _entidadRepository.UpdatexColaboradorAsync(command.IdColaborador, command.Estado);

                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(1);

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
                foreach (var h in command.PlanificacionHitos)
                {
                    var hito = _mapper.Map<PlanificacionHito>(h);
                    //await _entidadHitoRepository.UpdateAsync(hito);
                    obj.PlanificacionHitos.Add(hito);
                }


                await _entidadRepository.UpdateAsync(obj);


                
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(obj.Id);

            }
        }

    }
}
