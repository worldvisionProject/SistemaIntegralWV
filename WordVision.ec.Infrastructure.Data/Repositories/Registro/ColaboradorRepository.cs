using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly IRepositoryAsync<Colaborador> _repository;
        private readonly IDistributedCache _distributedCache;

        public ColaboradorRepository(IDistributedCache distributedCache, IRepositoryAsync<Colaborador> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Colaborador> Colaboradores => _repository.Entities;

        public async Task DeleteAsync(Colaborador colaborador)
        {
            await _repository.DeleteAsync(colaborador);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.GetKey(colaborador.Id));
        }

        public async Task<Colaborador> GetByIdAsync(int colaboradorId)
        {
            return await _repository.Entities.Where(p => p.Id == colaboradorId).FirstOrDefaultAsync();
        }

        public async Task<Colaborador> GetByIdentificacionAsync(string identificacion)
        {
            return await _repository.Entities.Where(p => p.Identificacion == identificacion).FirstOrDefaultAsync();
        }

        public async Task<Colaborador> GetByUserNameAsync(string username)
        {
            return await _repository.Entities.Where(p => p.Alias == username).FirstOrDefaultAsync();
        }

        public async Task<List<Colaborador>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Colaborador colaborador)
        {
            await _repository.AddAsync(colaborador);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            return colaborador.Id;
        }

        public async Task UpdateAsync(Colaborador colaborador)
        {
            await _repository.UpdateAsync(colaborador);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.GetKey(colaborador.Id));
        }
    }
}
