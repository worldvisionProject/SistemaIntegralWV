using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Infrastructure.Data.CacheKeys.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class EstructuraRepository : IEstructuraRepository
    {
        private readonly IRepositoryAsync<Estructura> _repository;
        private readonly IDistributedCache _distributedCache;

        public EstructuraRepository(IDistributedCache distributedCache, IRepositoryAsync<Estructura> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Estructura> Estructuras => _repository.Entities;

        public async Task DeleteAsync(Estructura estructura)
        {
            await _repository.DeleteAsync(estructura);
            await _distributedCache.RemoveAsync(EstructuraCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(EstructuraCacheKeys.GetKey(estructura.Id));
        }

        public async Task<Estructura> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).Include(c => c.Colaboradores).FirstOrDefaultAsync();
        }

        public async Task<List<Estructura>> GetListAsync()
        {
            return await _repository.Entities.Where(p => p.Estado == 1).Include(c=>c.Colaboradores).ToListAsync();
        }

        public async Task<int> InsertAsync(Estructura estructura)
        {
            await _repository.AddAsync(estructura);
            await _distributedCache.RemoveAsync(EstructuraCacheKeys.ListKey);
            return estructura.Id;
        }

        public async Task UpdateAsync(Estructura estructura)
        {
            await _repository.UpdateAsync(estructura);
            await _distributedCache.RemoveAsync(EstructuraCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(EstructuraCacheKeys.GetKey(estructura.Id));
        }
    }
}
