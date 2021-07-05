using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Infrastructure.Data.CacheKeys;
using WordVision.ec.Infrastructure.Data.CacheKeys.Maestro;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Maestro
{
    public class EstructuraCacheRepository : IEstructuraCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IEstructuraRepository _estructuraRepository;

        public EstructuraCacheRepository(IDistributedCache distributedCache, IEstructuraRepository estructuraRepository)
        {
            _distributedCache = distributedCache;
            _estructuraRepository = estructuraRepository;
        }
        public async Task<Estructura> GetByIdAsync(int id)
        {
            string cacheKey = EstructuraCacheKeys.GetKey(id);
            var estructura = await _distributedCache.GetAsync<Estructura>(cacheKey);
            if (estructura == null)
            {
                estructura = await _estructuraRepository.GetByIdAsync(id);
                Throw.Exception.IfNull(estructura, "estructura", "No estructura Found");
                await _distributedCache.SetAsync(cacheKey, estructura);
            }
            return estructura;
        }

        public async Task<List<Estructura>> GetCachedListAsync()
        {
            string cacheKey = EstructuraCacheKeys.ListKey;
            var estructuraList = await _distributedCache.GetAsync<List<Estructura>>(cacheKey);
            if (estructuraList == null)
            {
                estructuraList = await _estructuraRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, estructuraList);
            }
            return estructuraList;
        }
    }
}
