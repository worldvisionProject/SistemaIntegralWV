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
    class IndicadorProductoObjetivoRepository : IIndicadorProductoObjetivoRepository
    {
        private readonly IRepositoryAsync<IndicadorProductoObjetivo> _repository;
        private readonly IDistributedCache _distributedCache;

        public IndicadorProductoObjetivoRepository(IDistributedCache distributedCache, IRepositoryAsync<IndicadorProductoObjetivo> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<IndicadorProductoObjetivo> IndicadorProductoObjetivos => _repository.Entities;

        public async Task DeleteAsync(IndicadorProductoObjetivo entidad)
        {
            await _repository.DeleteAsync(entidad);
        }

        public async Task<IndicadorProductoObjetivo> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorProductoObjetivo>> GetByIdProductoObjetivoAsync(int idProductoObjetivo)
        {
            return await _repository.Entities.Where(c=>c.IdProductoObjetivo== idProductoObjetivo).ToListAsync();
        }

        public async Task<List<IndicadorProductoObjetivo>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(IndicadorProductoObjetivo entidad)
        {
            await _repository.AddAsync(entidad);
            return entidad.Id;
        }

        public async Task UpdateAsync(IndicadorProductoObjetivo entidad)
        {
            await _repository.UpdateAsync(entidad);
        }
    }
}
