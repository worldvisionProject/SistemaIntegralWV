using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Commands.Update
{
    public class UpdateIndicadorPOACommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string IndicadorProducto { get; set; }
        public string MedioVerificacion { get; set; }
        public int? Responsable { get; set; }
        public int? UnidadMedida { get; set; }
        public decimal? LineaBase { get; set; }
        public decimal? Meta { get; set; }
        public int IdProducto { get; set; }
        public ICollection<MetaTactica> MetaTacticas { get; set; }
        public ICollection<Actividad> Actividades { get; set; }
        public class UpdateIndicadorPOACommandHandler : IRequestHandler<UpdateIndicadorPOACommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IIndicadorPOARepository _IndicadorPOARepository;
            private readonly IMetaTacticaRepository _metaTacticaRepository;
            private readonly IActividadRepository _actividadRepository;
            private readonly IMapper _mapper;

            public UpdateIndicadorPOACommandHandler(IActividadRepository actividadRepository, IMetaTacticaRepository metaTacticaRepository, IIndicadorPOARepository IndicadorPOARepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _IndicadorPOARepository = IndicadorPOARepository;
                _metaTacticaRepository = metaTacticaRepository;
                _actividadRepository = actividadRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<int>> Handle(UpdateIndicadorPOACommand command, CancellationToken cancellationToken)
            {
                var IndicadorPOA = await _IndicadorPOARepository.GetByIdAsync(command.Id);

                if (IndicadorPOA == null)
                {
                    return Result<int>.Fail($"IndicadorPOA no encontrado.");
                }
                else
                {
                    IndicadorPOA.IndicadorProducto = command.IndicadorProducto ?? IndicadorPOA.IndicadorProducto;
                    IndicadorPOA.MedioVerificacion = command.MedioVerificacion ?? IndicadorPOA.MedioVerificacion;
                    IndicadorPOA.Responsable = command.Responsable ?? IndicadorPOA.Responsable;
                    IndicadorPOA.UnidadMedida = command.UnidadMedida ?? IndicadorPOA.UnidadMedida;
                    IndicadorPOA.LineaBase = command.LineaBase ?? IndicadorPOA.LineaBase;
                    IndicadorPOA.Meta = command.Meta ?? IndicadorPOA.Meta;

                    await _IndicadorPOARepository.UpdateAsync(IndicadorPOA);

                    foreach (var m in command.MetaTacticas)
                    {
                        var metaTactica = await _metaTacticaRepository.GetByIdAsync(m.Id);
                        if (metaTactica == null)
                        {
                            var meta = _mapper.Map<MetaTactica>(m);
                            meta.IdIndicadorPOA = IndicadorPOA.Id;
                            await _metaTacticaRepository.InsertAsync(meta);
                        }
                        else
                        {
                            metaTactica.NumMeses = m.NumMeses;
                            metaTactica.TipoMedida = m.TipoMedida;
                            metaTactica.Valor = m.Valor;
                            metaTactica.Entregable = m.Entregable;
                            await _metaTacticaRepository.UpdateAsync(metaTactica);
                        }


                    }

                    foreach (var a in command.Actividades)
                    {

                        var actividad = await _actividadRepository.GetByIdAsync(a.Id);
                        if (actividad == null)
                        {
                            var activ = _mapper.Map<Actividad>(a);
                            activ.IdIndicadorPOA = IndicadorPOA.Id;
                            await _actividadRepository.InsertAsync(activ);
                        }
                        else
                        {
                            actividad.DescripcionActividad = a.DescripcionActividad;
                            actividad.Entregable = a.Entregable;
                            actividad.IdCargoResponsable = a.IdCargoResponsable;
                            actividad.FechaInicio = a.FechaInicio;
                            actividad.FechaFin = a.FechaFin;
                            actividad.TechoPresupuestoCC = a.TechoPresupuestoCC;
                            actividad.Ponderacion = a.Ponderacion;

                            await _actividadRepository.UpdateAsync(actividad);
                        }
                    }



                    await _unitOfWork.Commit(cancellationToken);
                    return Result<int>.Success(IndicadorPOA.Id);
                }
            }
        }

    }
}
