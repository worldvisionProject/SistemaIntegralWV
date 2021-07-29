using AspNetCoreHero.ThrowR;
using AspNetCoreHero.Extensions.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Domain.Entities.Planificacion;
using WordVision.ec.Infrastructure.Data.CacheKeys.Planificacion;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Planificacion
{
    public class IndicadorEstrategicoCacheRepository : IIndicadorEstrategicoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IIndicadorEstrategicoRepository _repository;
        public IndicadorEstrategicoCacheRepository(IDistributedCache distributedCache, IIndicadorEstrategicoRepository repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public async Task<IndicadorEstrategico> GetByIdAsync(int indicadorEstrategico)
        {
            string cacheKey = IndicadorEstrategicosCacheKeys.GetKey(indicadorEstrategico);
            var entidad = await _distributedCache.GetAsync<IndicadorEstrategico>(cacheKey);
            if (entidad == null)
            {
                entidad = await _repository.GetByIdAsync(indicadorEstrategico,0);
                Throw.Exception.IfNull(entidad, "Estrategia", "Estrategia no encontrado");
                await _distributedCache.SetAsync(cacheKey, entidad);
            }
            return entidad;
        }

        public async Task<List<IndicadorEstrategico>> GetCachedListAsync()
        {
            string cacheKey = IndicadorEstrategicosCacheKeys.ListKey;
            var entidadList = await _distributedCache.GetAsync<List<IndicadorEstrategico>>(cacheKey);
            if (entidadList == null)
            {
                entidadList = await _repository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, entidadList);
            }
            return entidadList;
        }
    }
}
