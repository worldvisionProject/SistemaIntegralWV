﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class EstrategiaNacionalRepository : IEstrategiaNacionalRepository
    {
        private readonly IRepositoryAsync<EstrategiaNacional> _repository;
        private readonly IDistributedCache _distributedCache;

        public EstrategiaNacionalRepository(IDistributedCache distributedCache, IRepositoryAsync<EstrategiaNacional> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<EstrategiaNacional> EstrategiaNacionales => _repository.Entities;

        public async Task DeleteAsync(EstrategiaNacional estrategiaNacional)
        {
            await _repository.DeleteAsync(estrategiaNacional);
        }

        public async Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId)
        {
            return await _repository.Entities.Where(p => p.Id == estrategiaNacionalId)
                .Include(x => x.ObjetivoEstrategicos).ThenInclude(c => c.FactorCriticoExitos).ThenInclude(d=>d.IndicadorEstrategicos)
                .ThenInclude(a=>a.IndicadorAFs)
                .Include(y => y.Gestiones.OrderBy(c => c.FechaDesde)).Include(y => y.IndicadorCicloEstrategicos).FirstOrDefaultAsync();
        }
        public async Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId, int idColaborador)
        {
            return await _repository.Entities.Where(p => p.Id == estrategiaNacionalId)
                .Include(x => x.ObjetivoEstrategicos).ThenInclude(c => c.FactorCriticoExitos)
                .ThenInclude(i => i.IndicadorEstrategicos.Where(c => c.Responsable == idColaborador))
                .ThenInclude(a => a.IndicadorAFs)
                .Include(y => y.Gestiones.OrderBy(c => c.FechaDesde)).Include(y => y.IndicadorCicloEstrategicos).FirstOrDefaultAsync();
        }
        public async Task<EstrategiaNacional> GetByIdxTacticoAsync(int estrategiaNacionalId, int idColaborador, int idReportaA)
        {
            return await _repository.Entities.Where(p => p.Id == estrategiaNacionalId)
                .Include(x => x.ObjetivoEstrategicos)
                .ThenInclude(c => c.FactorCriticoExitos)
                .ThenInclude(i => i.IndicadorEstrategicos)

                .ThenInclude(p => p.Productos.Where(c => c.IdCargoResponsable == idColaborador))
                .ThenInclude(p => p.IndicadorPOAs.Where(c => c.Responsable == idColaborador))
                .Include(y => y.Gestiones).Include(y => y.IndicadorCicloEstrategicos).FirstOrDefaultAsync();
        }

        public async Task<EstrategiaNacional> GetByIdxOperativoAsync(int estrategiaNacionalId, int idColaborador, int idReportaA)
        {
            return await _repository.Entities.Where(p => p.Id == estrategiaNacionalId)
                .Include(x => x.ObjetivoEstrategicos)
                .ThenInclude(c => c.FactorCriticoExitos)
                .ThenInclude(i => i.IndicadorEstrategicos)
                .ThenInclude(p => p.Productos)
                .ThenInclude(p => p.IndicadorPOAs)
                .ThenInclude(a => a.Actividades.Where(c => c.IdCargoResponsable == idColaborador))
                .Include(y => y.Gestiones).Include(y => y.IndicadorCicloEstrategicos)
                .FirstOrDefaultAsync();
        }
        public async Task<List<EstrategiaNacional>> GetListAsync()
        {
            return await _repository.Entities.Include(x => x.ObjetivoEstrategicos).Include(s=>s.Gestiones).ToListAsync();

        }

        public async Task<int> InsertAsync(EstrategiaNacional estrategiaNacional)
        {
            await _repository.AddAsync(estrategiaNacional);
            return estrategiaNacional.Id;
        }

        public async Task UpdateAsync(EstrategiaNacional estrategiaNacional)
        {
            await _repository.UpdateAsync(estrategiaNacional);
        }

        public async Task<List<EstrategiaNacional>> GetListCiclosActivosAsync()
        {
             return await _repository.Entities.Include(x => x.ObjetivoEstrategicos).ToListAsync();
        }
    }
}
