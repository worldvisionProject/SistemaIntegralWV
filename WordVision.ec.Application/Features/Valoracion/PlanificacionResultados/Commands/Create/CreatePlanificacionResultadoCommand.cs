using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Commands.Create
{
    public partial class CreatePlanificacionResultadoCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdResultado { get; set; }

        public decimal? Meta { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? Ponderacion { get; set; }
        //public Resultado Resultados { get; set; }
        public string DatoManual1 { get; set; }

        public string DatoManual2 { get; set; }
        public int DatoManual3 { get; set; }
        public int TipoObjetivo { get; set; }
        public int IdObjetivoAnioFiscal { get; set; }
        public ObjetivoAnioFiscal ObjetivoAnioFiscales { get; set; }
        public ICollection<PlanificacionHito> PlanificacionHitos { get; set; }
    }
    public class CreatePlanificacionResultadoCommandHandler : IRequestHandler<CreatePlanificacionResultadoCommand, Result<int>>
    {
        private readonly IPlanificacionResultadoRepository _entidadRepository;
        private readonly IPlanificacionHitoRepository _entidadHitoRepository;
        private readonly IResponsabilidadRepository _responsabilidadRepository;
        private readonly ICompetenciaRepository _competenciaRepository;
        private readonly IResultadoRepository _resultadoRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreatePlanificacionResultadoCommandHandler(ICompetenciaRepository competenciaRepository,IResultadoRepository resultadoRepository,IResponsabilidadRepository responsabilidadRepository,IPlanificacionHitoRepository entidadHitoRepository,IPlanificacionResultadoRepository entidadRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _entidadRepository = entidadRepository;
            _entidadHitoRepository = entidadHitoRepository;
            _responsabilidadRepository = responsabilidadRepository;
            _competenciaRepository = competenciaRepository;
            _resultadoRepository = resultadoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreatePlanificacionResultadoCommand request, CancellationToken cancellationToken)
        {
            //if (request.Resultados.TipoObjetivo == 3)
            //{
            //    var _responsabilidad = await _responsabilidadRepository.GetByIdAsync(request.IdResultado);
            //    var objResponsa = _mapper.Map<Responsabilidad>(_responsabilidad);
            //    request.Resultados.Nombre = objResponsa.Nombre;
            //    request.Resultados.Indicador = objResponsa.Indicador;
            //    request.Resultados.Tipo = objResponsa.Tipo;
            //    request.Resultados.TipoObjetivo = 2;
            //    request.Resultados.ObjetivoAnioFiscales = null;
            //}
            //else if (request.Resultados.TipoObjetivo == 4)
            //{
            //    var _competencia = await _competenciaRepository.GetByIdAsync(request.IdResultado);
            //    var objResponsa = _mapper.Map<Competencia>(_competencia);
            //    request.Resultados.Nombre = objResponsa.NombreCompetencia;
            //    request.Resultados.Indicador = objResponsa.Comportamiento;
            //    request.Resultados.Tipo = 0;
            //    request.Resultados.TipoObjetivo = 3;
            //    request.Resultados.ObjetivoAnioFiscales = null;
            //}
            //else if (request.Resultados.TipoObjetivo == 5 || request.Resultados.TipoObjetivo == 7)
            //{
            //    var _competencia = await _competenciaRepository.GetByIdAsync(request.IdResultado);
            //    var objResponsa = _mapper.Map<Competencia>(_competencia);
            //    request.Resultados.Nombre = request.DatoManual1;
            //    request.Resultados.Indicador = String.Empty;
            //    request.Resultados.Tipo = 0;
            //    request.Resultados.TipoObjetivo = 4;
            //    request.Resultados.ObjetivoAnioFiscales = null;
            //}
            //else if (request.Resultados.TipoObjetivo == 6)
            //{
            //    var _competencia = await _competenciaRepository.GetByIdAsync(request.IdResultado);
            //    var objResponsa = _mapper.Map<Competencia>(_competencia);
            //    request.Resultados.Nombre = request.DatoManual1;
            //    request.Resultados.Indicador = request.DatoManual2;
            //    request.Resultados.Tipo = 0;
            //    request.Resultados.TipoObjetivo = 4;
            //    request.Resultados.ObjetivoAnioFiscales = null;
            //}
            //else if (request.Resultados.TipoObjetivo == 1 || request.Resultados.TipoObjetivo == 2)
            //{
               request.ObjetivoAnioFiscales = null;
                //request.Resultados = null;
            //}
                
            var planificacion = _mapper.Map<PlanificacionResultado>(request);
            await _entidadRepository.InsertAsync(planificacion);
            foreach (var h in request.PlanificacionHitos)
            {
                var hito = _mapper.Map<PlanificacionHito>(h);
                await _entidadHitoRepository.InsertAsync(hito);
            }

            

            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(planificacion.Id);
        }

    }
}
