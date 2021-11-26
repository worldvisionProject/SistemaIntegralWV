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
    public class ObjetivoEstrategicoCacheRepository : IObjetivoEstrategicoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IObjetivoEstrategicoRepository _objetivoEstrategicoRepository;
        public ObjetivoEstrategicoCacheRepository(IDistributedCache distributedCache, IObjetivoEstrategicoRepository objetivoEstrategicoRepository)
        {
            _distributedCache = distributedCache;
            _objetivoEstrategicoRepository = objetivoEstrategicoRepository;
        }
        public async Task<ObjetivoEstrategico> GetByIdAsync(int objetivoEstrategicoId)
        {
            string cacheKey = ObjetivoEstrategicoCacheKeys.GetKey(objetivoEstrategicoId);
            var entidad = await _distributedCache.GetAsync<ObjetivoEstrategico>(cacheKey);
            if (entidad == null)
            {
                entidad = await _objetivoEstrategicoRepository.GetByIdAsync(objetivoEstrategicoId);
                Throw.Exception.IfNull(entidad, "Objetivo", "Objetivo no encontrado");
                await _distributedCache.SetAsync(cacheKey, entidad);
            }
            return entidad;
        }

        public async Task<List<ObjetivoEstrategico>> GetCachedListAsync()
        {
            string cacheKey = ObjetivoEstrategicoCacheKeys.ListKey;
            var entidadList = await _distributedCache.GetAsync<List<ObjetivoEstrategico>>(cacheKey);
            if (entidadList == null)
            {
                entidadList = await _objetivoEstrategicoRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, entidadList);
            }
            return entidadList;
        }


    }
}
