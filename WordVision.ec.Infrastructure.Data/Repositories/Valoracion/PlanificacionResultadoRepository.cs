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
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class PlanificacionResultadoRepository : IPlanificacionResultadoRepository
    {
        private readonly IRepositoryAsync<PlanificacionResultado> _repository;
        private readonly IRepositoryAsync<Objetivo> _repositoryObjetivo;
        private readonly IRepositoryAsync<Resultado> _repositoryResultado;
        private readonly IRepositoryAsync<Responsabilidad> _repositoryResponsabilidad;
        private readonly IRepositoryAsync<Competencia> _repositoryCompetencia;
        private readonly IDistributedCache _distributedCache;
        public PlanificacionResultadoRepository(IRepositoryAsync<Competencia> repositoryCompetencia,IRepositoryAsync<Responsabilidad> repositoryResponsabilidad,IRepositoryAsync<Resultado> repositoryResultado,IRepositoryAsync<PlanificacionResultado> repository, IRepositoryAsync<Objetivo> repositoryObjetivo, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _repositoryObjetivo = repositoryObjetivo;
            _repositoryResultado = repositoryResultado;
            _repositoryResponsabilidad = repositoryResponsabilidad;
            _repositoryCompetencia = repositoryCompetencia;

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
                //.Include(y =>y.Resultados)
                .Include(x => x.ObjetivoAnioFiscales)
                .ThenInclude(m => m.Objetivos)
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
            var result=_repository.Entities.Where(x => x.IdObjetivoAnioFiscal == idObjetivoAnioFiscal && x.IdColaborador == idColaborador)
                .Select(a => new PlanificacionResultadoResponse
                {
                    IdResultado = a.IdResultado,
                    Nombre = a.TipoObjetivo==1?_repositoryResultado.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Nombre).FirstOrDefault(): a.TipoObjetivo==2? _repositoryResponsabilidad.Entities.Where(b => b.Id == a.IdResultado && b.IdObjetivoAnioFiscal == a.IdObjetivoAnioFiscal).Select(g => g.Nombre).FirstOrDefault(): a.TipoObjetivo == 3 ? _repositoryCompetencia.Entities.Where(b => b.Id == a.IdResultado ).Select(g => g.NombreCompetencia).FirstOrDefault():"",
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
                    DatoManual1=a.DatoManual1,
                    DatoManual2 = a.DatoManual2,
                    DatoManual3 = a.DatoManual3,
                })
                .ToListAsync();

            return await result;
           // 
        }

        public async Task<List<PlanificacionResultado>> GetListxObjetivoAsync(int idObjetivo)
        {
            return await _repository.Entities//.Include(x => x.Resultados)
               .Include(x => x.ObjetivoAnioFiscales)
               .ThenInclude(m => m.Objetivos).Where(c => c.ObjetivoAnioFiscales.IdObjetivo==idObjetivo)
               .ToListAsync();
        }

        public async Task<List<ObjetivoResponse>> GetListxObjetivoxColaboradorAsync(int idAnioFiscal, int idColaborador)
        {
            var newsDtoList = _repositoryObjetivo.Entities.Include(x => x.ObjetivoAnioFiscales)
                //.ThenInclude(o => o.Resultados)
                .ThenInclude(o => o.PlanificacionResultados)
            .Select(x => new ObjetivoResponse
            {
                IdObjetivo=x.Id,
                NombreObjetivo = x.Nombre,
                Numero = x.Numero,
                Descripcion = x.Descripcion,
                Estado = x.Estado,
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
                        DatoManual3 = a.DatoManual3
                    }).Where(n=>n.IdColaborador==idColaborador).ToList()
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
    }
}
