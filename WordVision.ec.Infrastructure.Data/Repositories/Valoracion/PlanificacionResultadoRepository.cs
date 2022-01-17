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
        private readonly IRepositoryAsync<Objetivo> _repositoryResultado;
        private readonly IDistributedCache _distributedCache;
        public PlanificacionResultadoRepository(IRepositoryAsync<PlanificacionResultado> repository, IRepositoryAsync<Objetivo> repositoryResultado, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _repositoryResultado = repositoryResultado;
        }
        public IQueryable<PlanificacionResultado> planificacionResultados => _repository.Entities;
        public IQueryable<Objetivo> resultados => _repositoryResultado.Entities;

        public async Task DeleteAsync(PlanificacionResultado planificacionResultado)
        {
            await _repository.DeleteAsync(planificacionResultado);
        }

        public async Task<PlanificacionResultado> GetByIdAsync(int planificacionResultadoId)
        {
            return await _repository.Entities.Where(x => x.Id == planificacionResultadoId)
                .Include(y =>y.Resultados)
                .ThenInclude(x => x.ObjetivoAnioFiscales)
                .ThenInclude(m => m.Objetivos)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PlanificacionResultado>> GetListAsync()
        {
            return await _repository.Entities.Include(x => x.Resultados)
                .ThenInclude(x => x.ObjetivoAnioFiscales)
                .ThenInclude(m => m.Objetivos)
                .ToListAsync();

        }

        public async Task<List<PlanificacionResultado>> GetListxObjetivoAsync(int idObjetivo)
        {
            return await _repository.Entities.Include(x => x.Resultados)
               .ThenInclude(x => x.ObjetivoAnioFiscales)
               .ThenInclude(m => m.Objetivos).Where(c => c.Resultados.ObjetivoAnioFiscales.IdObjetivo==idObjetivo)
               .ToListAsync();
        }

        public async Task<List<ObjetivoResponse>> GetListxObjetivoxColaboradorAsync(int idAnioFiscal, int idColaborador)
        {
            var newsDtoList = _repositoryResultado.Entities.Include(x => x.ObjetivoAnioFiscales)
                .ThenInclude(o => o.Resultados).ThenInclude(o => o.PlanificacionResultados)
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
                    PlanificacionResultados = q.Resultados.Select(a => new PlanificacionResultadoResponse
                    {
                      IdResultado=a.Id,
                      Nombre=a.Nombre,
                      Indicador=a.Indicador,
                      Tipo=a.Tipo,
                      IdColaborador=a.PlanificacionResultados.Where(u => u.IdResultado==a.Id).Select(q => q.IdColaborador).FirstOrDefault(),
                        IdPlanificacion = a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Id).FirstOrDefault(),
                        Meta = a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Meta).FirstOrDefault(),
                        FechaInicio = a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.FechaInicio).FirstOrDefault(),
                        FechaFin = a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.FechaFin).FirstOrDefault(),
                        Ponderacion = a.PlanificacionResultados.Where(u => u.IdResultado == a.Id).Select(q => q.Ponderacion).FirstOrDefault()
                    }).ToList()
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
