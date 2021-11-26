using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly IRepositoryAsync<Actividad> _repository;
        private readonly IDistributedCache _distributedCache;

        public ActividadRepository(IDistributedCache distributedCache, IRepositoryAsync<Actividad> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Actividad> Actividades => _repository.Entities;

        public async Task DeleteAsync(Actividad actividad)
        {
            await _repository.DeleteAsync(actividad);
        }

        public async Task<Actividad> GetByIdAsync(int actividadId)
        {
            return await _repository.Entities.Where(p => p.Id == actividadId).Include(r => r.Recursos).FirstOrDefaultAsync();
        }

        public async Task<List<Actividad>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Actividad>> GetListByIdAsync(int idIndicador)
        {
            return await _repository.Entities.Where(x => x.IdIndicadorPOA == idIndicador).ToListAsync();
        }

        public async Task<List<Actividad>> GetListxObjetivoAsync(int idObjetivoEstrategico, int idColaborador)
        {
            return await _repository.Entities
                            .Include(i => i.IndicadorPOAs)
                            .ThenInclude(p => p.Productos)
                            .ThenInclude(i => i.IndicadorEstrategicos)
                            .ThenInclude(a => a.IndicadorAFs)
                            .ThenInclude(ie => ie.IndicadorEstrategicos)
                            .ThenInclude(fc => fc.FactorCriticoExitos).Where(dd => dd.IndicadorPOAs.Productos.IndicadorEstrategicos.FactorCriticoExitos.IdObjetivoEstra == idObjetivoEstrategico && dd.IdCargoResponsable == idColaborador)
                            .ToListAsync();
        }

        public async Task<int> InsertAsync(Actividad actividad)
        {
            await _repository.AddAsync(actividad);
            return actividad.Id;
        }

        public async Task UpdateAsync(Actividad actividad)
        {
            await _repository.UpdateAsync(actividad);
        }
    }
}
