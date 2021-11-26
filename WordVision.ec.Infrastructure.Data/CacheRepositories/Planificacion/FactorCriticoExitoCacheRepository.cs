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
    public class FactorCriticoExitoCacheRepository : IFactorCriticoExitoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IFactorCriticoExitoRepository _repository;
        public FactorCriticoExitoCacheRepository(IDistributedCache distributedCache, IFactorCriticoExitoRepository repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public async Task<FactorCriticoExito> GetByIdAsync(int factorCriticoExitoId)
        {
            string cacheKey = FactorCriticoExitoCacheKeys.GetKey(factorCriticoExitoId);
            var entidad = await _distributedCache.GetAsync<FactorCriticoExito>(cacheKey);
            if (entidad == null)
            {
                entidad = await _repository.GetByIdAsync(factorCriticoExitoId);
                Throw.Exception.IfNull(entidad, "Factor", "Factor no encontrado");
                await _distributedCache.SetAsync(cacheKey, entidad);
            }
            return entidad;
        }

        public async Task<List<FactorCriticoExito>> GetCachedListAsync()
        {
            string cacheKey = FactorCriticoExitoCacheKeys.ListKey;
            var entidadList = await _distributedCache.GetAsync<List<FactorCriticoExito>>(cacheKey);
            if (entidadList == null)
            {
                entidadList = await _repository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, entidadList);
            }
            return entidadList;
        }
    }
}
