using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class PlanificacionResultadoRepository : IPlanificacionResultadoRepository
    {
        private readonly IRepositoryAsync<PlanificacionResultado> _repository;
        private readonly IRepositoryAsync<Objetivo> _repositoryObjetivo;
        private readonly IRepositoryAsync<ObjetivoAnioFiscal> _repositoryObjetivoAnioFiscal;
        private readonly IRepositoryAsync<Resultado> _repositoryResultado;
        private readonly IRepositoryAsync<Responsabilidad> _repositoryResponsabilidad;
        private readonly IRepositoryAsync<Competencia> _repositoryCompetencia;
        private readonly IRepositoryAsync<Colaborador> _repositoryColaborador;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalleCatalogo;
        private readonly IRepositoryAsync<SeguimientoObjetivo> _repositorySeguimientoObjetivo;
        private readonly IRepositoryAsync<PlanificacionComportamiento> _repositoryPlaniComportamiento;
        private readonly IRepositoryAsync<Escala> _repositoryEscala;

        private readonly IDistributedCache _distributedCache;
        public PlanificacionResultadoRepository(IRepositoryAsync<ObjetivoAnioFiscal> repositoryObjetivoAnioFiscal,IRepositoryAsync<Escala> repositoryEscala,IRepositoryAsync<PlanificacionComportamiento> repositoryPlaniComportamiento,IRepositoryAsync<SeguimientoObjetivo> repositorySeguimientoObjetivo,IRepositoryAsync<DetalleCatalogo> repositoryDetalleCatalogo,IRepositoryAsync<Colaborador> repositoryColaborador,IRepositoryAsync<Competencia> repositoryCompetencia,IRepositoryAsync<Responsabilidad> repositoryResponsabilidad,IRepositoryAsync<Resultado> repositoryResultado,IRepositoryAsync<PlanificacionResultado> repository, IRepositoryAsync<Objetivo> repositoryObjetivo, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _repositoryObjetivo = repositoryObjetivo;
            _repositoryObjetivoAnioFiscal = repositoryObjetivoAnioFiscal;
            _repositoryResultado = repositoryResultado;
            _repositoryResponsabilidad = repositoryResponsabilidad;
            _repositoryCompetencia = repositoryCompetencia;
            _repositoryColaborador = repositoryColaborador;
            _repositoryDetalleCatalogo = repositoryDetalleCatalogo;
            _repositorySeguimientoObjetivo = repositorySeguimientoObjetivo;
            _repositoryPlaniComportamiento = repositoryPlaniComportamiento;
            _repositoryEscala = repositoryEscala;

        }
        public IQueryable<PlanificacionResultado> planificacionResultados => _repository.Entities;
        public IQueryable<Objetivo> resultados => _repositoryObjetivo.Entities;

        public async Task DeleteAsync(PlanificacionResultado planificacionResultado)
        {
            await _repository.DeleteAsync(planificacionResultado);
        }

        public async Task<PlanificacionResultado> GetByIdAsync(int planificacionResultadoId)
        {
            return await _repository.Entities.Where(x => x.Id == planificacionResultadoId)
                .Include(p=>p.PlanificacionHitos)
                .Include(y =>y.AvanceObjetivos)
                .Include(x => x.ObjetivoAnioFiscales)
                .ThenInclude(m => m.Objetivos)
                .Include(y => y.PlanificacionComportamientos)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PlanificacionResultado>> GetListAsync()
        {
            return await _repository.Entities//.Include(x => x.Resultados)
                .Include(x => x.ObjetivoAnioFiscales)
                .ThenInclude(m => m.Objetivos)
                .ToListAsync();

        }

        public async Task<List<PlanificacionResultadoResponse>> GetListxColaboradorAsync(int idObjetivoAnioFiscal, int idColaborador)
        {
            var result = _repository.Entities.Where(x => x.IdObjetivoAnioFiscal == idObjetivoAnioFiscal && x.IdColaborador == idColaborador)
                .Select(a => new PlanificacionResultadoResponse
                {
                    IdResultado = a.IdResultado,
                    Nombre = a.TipoObjetivo == 1 ? _repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Nombre).FirstOrDefault() : a.TipoObjetivo == 2 ? _repositoryResponsabilidad.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Nombre).FirstOrDefault() : a.TipoObjetivo == 3 ? _repositoryCompetencia.Entities.Where(b => b.Id == a.IdResultado).Select(g => g.NombreCompetencia).FirstOrDefault() : "",
                    Descripcion = a.TipoObjetivo == 1 ? _repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Descripcion).FirstOrDefault() : a.TipoObjetivo == 2 ? _repositoryResponsabilidad.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Descripcion).FirstOrDefault() : a.TipoObjetivo == 3 ? _repositoryCompetencia.Entities.Where(b => b.Id == a.IdResultado).Select(g => g.Descripcion).FirstOrDefault() : "",
                    Indicador = a.TipoObjetivo == 1 ? _repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Indicador).FirstOrDefault() : a.TipoObjetivo == 2 ? _repositoryResponsabilidad.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Indicador).FirstOrDefault() : a.TipoObjetivo == 3 ? _repositoryCompetencia.Entities.Where(b => b.Id == a.IdResultado).Select(g => g.Comportamiento).FirstOrDefault() : "",
                    Tipo = a.TipoObjetivo == 1 ? _repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Tipo).FirstOrDefault() : a.TipoObjetivo == 2 ? _repositoryResponsabilidad.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Tipo).FirstOrDefault() : 0,
                    TipoObjetivo = a.TipoObjetivo,
                    IdColaborador = a.IdColaborador,//PlanificacionResultados.Where(u => u.IdResultado==a.Id).Select(q => q.IdColaborador).FirstOrDefault(),
                    IdPlanificacion = a.Id,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Id).FirstOrDefault(),
                    Meta = a.Meta,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Meta).FirstOrDefault(),
                    FechaInicio = a.FechaInicio,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.FechaInicio).FirstOrDefault(),
                    FechaFin = a.FechaFin,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.FechaFin).FirstOrDefault(),
                    Ponderacion = a.Ponderacion,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Ponderacion).FirstOrDefault()
                    DatoManual1 = a.DatoManual1,
                    DatoManual2 = a.DatoManual2,
                    DatoManual3 = a.DatoManual3,
                    Estado=a.Estado,
                    ObservacionLider=a.ObservacionLider,
                    Comportamientos = _repositoryPlaniComportamiento.Entities.Where(u => u.IdPlanificacion == a.Id).Select(c => new ComportamientoResponse
                    {
                        IdCompetencia = c.IdCompetencia,
                        DescCompetencia = _repositoryCompetencia.Entities.Where(b => b.Id == c.IdCompetencia).Select(g => g.Comportamiento).FirstOrDefault(),
                        IdPlanificacion =c.IdPlanificacion,
                        FechaInicio=c.FechaInicio,
                        FechaFin=c.FechaFin
                    }).ToList()

                    })
                .ToListAsync();

            return await result;
           // 
        }

        public async Task<List<PlanificacionResultadoResponse>> GetListxLiderAsync(int idLider)
        {
            var result = _repository.Entities.Where(x => x.ReportaId == idLider && (x.Estado!= 1))
                .GroupBy(x=> new { x.IdColaborador ,x.Estado,x.ObjetivoAnioFiscales.AnioFiscal })
                 .Select(a => new PlanificacionResultadoResponse
                 {
                     ValorValoracionFinal= _repositorySeguimientoObjetivo.Entities.Where(c=>c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal== a.Key.AnioFiscal && c.Ultimo==1 && (c.Estado==5 || c.Estado == 6)).FirstOrDefault().ValorValoracionFinal,
                     ValoracionFinal = _repositorySeguimientoObjetivo.Entities.Where(c => c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal == a.Key.AnioFiscal && c.Ultimo == 1 && (c.Estado == 5 || c.Estado == 6)).FirstOrDefault().ValoracionFinal,
                     ValoracionLider1 = _repositorySeguimientoObjetivo.Entities.Where(c => c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal == a.Key.AnioFiscal && c.Ultimo == 1 && (c.Estado == 5 || c.Estado == 6)).FirstOrDefault().ValoracionLider1,
                     ComentarioColaborador = _repositorySeguimientoObjetivo.Entities.Where(c => c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal == a.Key.AnioFiscal && c.Ultimo == 1 && (c.Estado == 5 || c.Estado == 6)).FirstOrDefault().ComentarioColaborador,
                     ComentarioLider1 = _repositorySeguimientoObjetivo.Entities.Where(c => c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal == a.Key.AnioFiscal && c.Ultimo == 1 &&  (c.Estado == 5 || c.Estado == 6)).FirstOrDefault().ComentarioLider1,
                     ComentarioLider2 = _repositorySeguimientoObjetivo.Entities.Where(c => c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal == a.Key.AnioFiscal && c.Ultimo == 1 && (c.Estado == 5 || c.Estado == 6)).FirstOrDefault().ComentarioLider2,
                     ComentarioLiderMatricial = _repositorySeguimientoObjetivo.Entities.Where(c => c.IdColaborador == a.Key.IdColaborador && c.AnioFiscal == a.Key.AnioFiscal && c.Ultimo == 1 && (c.Estado == 5 || c.Estado == 6)).FirstOrDefault().ComentarioLiderMatricial,

                     AnioFiscal = a.Key.AnioFiscal,
                    IdColaborador = a.Key.IdColaborador,
                    Estado=a.Key.Estado,
                    DescEstado = _repositoryDetalleCatalogo.Entities.Where(c=>c.IdCatalogo==45 && c.Secuencia==a.Key.Estado.ToString()).FirstOrDefault().Nombre,
                    NombreColaborador = _repositoryColaborador.Entities.Where(x=>x.Id==a.Key.IdColaborador).FirstOrDefault().Apellidos+" "+_repositoryColaborador.Entities.Where(x => x.Id == a.Key.IdColaborador).FirstOrDefault().ApellidoMaterno + " " + _repositoryColaborador.Entities.Where(x => x.Id == a.Key.IdColaborador).FirstOrDefault().PrimerNombre + " " + _repositoryColaborador.Entities.Where(x => x.Id == a.Key.IdColaborador).FirstOrDefault().SegundoNombre
                 })
                 .ToListAsync();

            return await result;
        }

        public async Task<List<PlanificacionResultado>> GetListxObjetivoAsync(int idObjetivo)
        {
            return await _repository.Entities//.Include(x => x.Resultados)
               .Include(x => x.ObjetivoAnioFiscales)
               .ThenInclude(m => m.Objetivos).Where(c => c.ObjetivoAnioFiscales.IdObjetivo==idObjetivo)
               .ToListAsync();
        }

        public async Task<List<ObjetivoResponse>> GetListxObjetivoxColaboradorAsync(int idAnioFiscal, int idColaborador,int perfil)
        {
            var repestado = _repositorySeguimientoObjetivo.Entities.Where(v => v.AnioFiscal == idAnioFiscal && v.IdColaborador == idColaborador && v.Ultimo == 1).FirstOrDefault();
            int estado = 1;
            if (repestado != null)
                estado = repestado.Estado;
            var newsDtoList = _repositoryObjetivo.Entities.Include(x => x.ObjetivoAnioFiscales)
                //.ThenInclude(o => o.Resultados)
                .ThenInclude(o => o.PlanificacionResultados)
            .Select(x => new ObjetivoResponse
            {
                IdColaborador = idColaborador,
                IdObjetivo =x.Id,
                NombreObjetivo = x.Nombre,
                Numero = x.Numero,
                Descripcion = x.Descripcion,
                Estado = x.Estado,
                EstadoProceso= estado,
                DescEstadoProceso= _repositoryDetalleCatalogo.Entities.Where(c => c.IdCatalogo == 45 && c.Secuencia == estado.ToString()).FirstOrDefault().Nombre,
                Perfil= perfil,
                ComentarioColaborador= _repositorySeguimientoObjetivo.Entities.Where(s=>s.AnioFiscal== idAnioFiscal && s.IdColaborador== idColaborador && s.Ultimo==1).FirstOrDefault().ComentarioColaborador,
                ComentarioLider1 = _repositorySeguimientoObjetivo.Entities.Where(s => s.AnioFiscal == idAnioFiscal && s.IdColaborador == idColaborador && s.Ultimo == 1).FirstOrDefault().ComentarioLider1,
                ComentarioLider2 = _repositorySeguimientoObjetivo.Entities.Where(s => s.AnioFiscal == idAnioFiscal && s.IdColaborador == idColaborador && s.Ultimo == 1).FirstOrDefault().ComentarioLider2,
                ComentarioLiderMatricial = _repositorySeguimientoObjetivo.Entities.Where(s => s.AnioFiscal == idAnioFiscal && s.IdColaborador == idColaborador && s.Ultimo == 1).FirstOrDefault().ComentarioLiderMatricial,
                //ValorValoracionFinal = x.ObjetivoAnioFiscales.Select(l=> l.PlanificacionResultados.Count()).FirstOrDefault(),
                //ValoracionFinal = _repositoryEscala.Entities.Where(e => e.EscalaInicio>= x.ObjetivoAnioFiscales.Select(b => b.PlanificacionResultados.Where(n => n.IdColaborador == idColaborador).Sum(s => s.PonderacionResultado).GetValueOrDefault() ).FirstOrDefault()).FirstOrDefault().Calificacion,
                ValoracionLider1 = _repositorySeguimientoObjetivo.Entities.Where(s => s.AnioFiscal == idAnioFiscal && s.IdColaborador == idColaborador && s.Ultimo == 1).FirstOrDefault().ValoracionLider1,

                AnioFiscales = x.ObjetivoAnioFiscales.Select(q => new ObjetivoAnioFiscalResponse
                {
                    Id = q.Id,
                    AnioFiscal = q.AnioFiscal,
                    Ponderacion=q.Ponderacion,
                    PlanificacionResultados = q.PlanificacionResultados.Select(a => new PlanificacionResultadoResponse
                    {
                      IdResultado=a.IdResultado,
                      Nombre= _repositoryResultado.Entities.Where(b=>b.Id== a.IdResultado && b.IdObjetivoAnioFiscal==a.IdObjetivoAnioFiscal).Select(g=>g.Nombre).FirstOrDefault(),
                      Indicador = _repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Indicador).FirstOrDefault(),
                        Tipo = _repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Tipo).FirstOrDefault(),
                        TipoObjetivo = a.TipoObjetivo,
                        IdColaborador =a.IdColaborador,//PlanificacionResultados.Where(u => u.IdResultado==a.Id).Select(q => q.IdColaborador).FirstOrDefault(),
                        IdPlanificacion =a.Id,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Id).FirstOrDefault(),
                        Meta =a.Meta,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Meta).FirstOrDefault(),
                        FechaInicio =a.FechaInicio,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.FechaInicio).FirstOrDefault(),
                        FechaFin =a.FechaFin,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.FechaFin).FirstOrDefault(),
                        Ponderacion =a.Ponderacion,// a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Ponderacion).FirstOrDefault()
                        DatoManual1=a.DatoManual1,
                        DatoManual2= a.DatoManual2,
                        DatoManual3 = a.DatoManual3,
                        FechaCumplimiento=a.FechaCumplimiento,
                        PonderacionResultado=a.PonderacionResultado,
                        PorcentajeCumplimiento=a.PorcentajeCumplimiento

                    }).Where(n=>n.IdColaborador==idColaborador).ToList(),
                    ValorValoracionFinal=q.PlanificacionResultados.Count()
                }).Where(o => o.AnioFiscal== idAnioFiscal).ToList(),
                
                //PlanificacionResultado= x.
                //IdResultado = x.Resultados.Id,
                //Nombre = x.Resultados.Nombre,
                //Indicador = x.Resultados.Indicador,
                //Tipo = x.Resultados.Tipo,
                //IdColaborador = x.IdColaborador,
                //IdPlanificacion=x.Id,
                //Meta=x.Meta,
                //FechaInicio=x.FechaInicio,
                //FechaFin=x.FechaFin,
                //Ponderacion=x.Ponderacion,
            }).ToListAsync();

            return await newsDtoList;
        }

        public async Task<int> InsertAsync(PlanificacionResultado planificacionResultado)
        {
            await _repository.AddAsync(planificacionResultado);
            return planificacionResultado.Id;
        }

        public async Task UpdateAsync(PlanificacionResultado planificacionResultado)
        {
            await _repository.UpdateAsync(planificacionResultado);
        }
        public async Task UpdatexColaboradorAsync(int idColaborador,int estado, int idAnioFiscal)
        {
           var e= _repositoryObjetivoAnioFiscal.Entities.Include(c=>c.PlanificacionResultados.Where(x => x.IdColaborador == idColaborador)).Where(e=>e.AnioFiscal== idAnioFiscal).ToList();
            foreach (var e2 in e.SelectMany(v=>v.PlanificacionResultados))
            {
                e2.Estado = estado;
                await _repository.UpdateAsync(e2);
            }
               
        }

        public async Task<List<PlanificacionResultado>> GetListObjetivoxColaboradorAsync(int idObjetivo, int idColaborador)
        {
            return await _repository.Entities//.Include(x => x.Resultados)
              .Include(x => x.ObjetivoAnioFiscales)
              .ThenInclude(m => m.Objetivos).Where(c => c.ObjetivoAnioFiscales.IdObjetivo == idObjetivo && c.IdColaborador==idColaborador)
              .ToListAsync();
        }
    }
}
