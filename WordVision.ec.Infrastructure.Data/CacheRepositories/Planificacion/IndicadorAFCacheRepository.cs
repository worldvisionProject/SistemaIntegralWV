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
    public class IndicadorAFCacheRepository : IIndicadorAFCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IIndicadorAFRepository _repository;
        public IndicadorAFCacheRepository(IDistributedCache distributedCache, IIndicadorAFRepository repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public async Task<IndicadorAF> GetByIdAsync(int indicadorAFId)
        {
            string cacheKey = IndicadorAFCacheKeys.GetKey(indicadorAFId);
            var entidad = await _distributedCache.GetAsync<IndicadorAF>(cacheKey);
            if (entidad == null)
            {
                entidad = await _repository.GetByIdAsync(indicadorAFId);
                Throw.Exception.IfNull(entidad, "Factor", "Factor no encontrado");
                await _distributedCache.SetAsync(cacheKey, entidad);
            }
            return entidad;
        }

        public async Task<List<IndicadorAF>> GetCachedListAsync()
        {
            string cacheKey = IndicadorAFCacheKeys.ListKey;
            var entidadList = await _distributedCache.GetAsync<List<IndicadorAF>>(cacheKey);
            if (entidadList == null)
            {
                entidadList = await _repository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, entidadList);
            }
            return entidadList;
        }
    }
}
