using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Planificacion
{
    public class EstrategiaNacionalCacheRepository : IEstrategiaNacionalCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IEstrategiaNacionalRepository _repository;
        public EstrategiaNacionalCacheRepository(IDistributedCache distributedCache, IEstrategiaNacionalRepository repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public async Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId)
        {
            string cacheKey = EstrategiaNacionalCacheKeys.GetKey(estrategiaNacionalId);
            var entidad = await _distributedCache.GetAsync<EstrategiaNacional>(cacheKey);
            if (entidad == null)
            {
                entidad = await _repository.GetByIdAsync(estrategiaNacionalId);
                Throw.Exception.IfNull(entidad, "Estrategia", "Estrategia no encontrado");
                await _distributedCache.SetAsync(cacheKey, entidad);
            }
            return entidad;
        }

        public async Task<List<EstrategiaNacional>> GetCachedListAsync()
        {
            string cacheKey = EstrategiaNacionalCacheKeys.ListKey;
            var entidadList = await _distributedCache.GetAsync<List<EstrategiaNacional>>(cacheKey);
            if (entidadList == null)
            {
                entidadList = await _repository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, entidadList);
            }
            return entidadList;
        }
    }
}
