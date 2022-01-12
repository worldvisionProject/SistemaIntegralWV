using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;
using WordVision.ec.Infrastructure.Data.CacheKeys.Valoracion;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Valoracion
{
    public class ObjetivoCacheRepository : IObjetivoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IObjetivoRepository _objetivoRepository;

        public ObjetivoCacheRepository(IDistributedCache distributedCache, IObjetivoRepository objetivoRepository)
        {
            _distributedCache = distributedCache;
            _objetivoRepository = objetivoRepository;
        }
        public async Task<Objetivo> GetByIdAsync(int objetivoId)
        {
            string cacheKey = ObjetivoCacheKeys.GetKey(objetivoId);
            var objetivo = await _distributedCache.GetAsync<Objetivo>(cacheKey);
            if (objetivo == null)
            {
                objetivo = await _objetivoRepository.GetByIdAsync(objetivoId);
                Throw.Exception.IfNull(objetivo, "objetivo", "No objetivo Found");
                await _distributedCache.SetAsync(cacheKey, objetivo);
            }
            return objetivo;
        }

        public async Task<List<Objetivo>> GetCachedListAsync()
        {
            string cacheKey = ObjetivoCacheKeys.ListKey;
            var objetivoList = await _distributedCache.GetAsync<List<Objetivo>>(cacheKey);
            if (objetivoList == null)
            {
                objetivoList = await _objetivoRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, objetivoList);
            }
            return objetivoList;
        }

        public async Task<List<Objetivo>> GetCachedListxAnioFiscalAsync(int idAnioFiscal)
        {
            string cacheKey = ObjetivoCacheKeys.ListKey;
            var objetivoList = await _distributedCache.GetAsync<List<Objetivo>>(cacheKey);
            if (objetivoList == null || objetivoList.Count == 0)
            {
                objetivoList = await _objetivoRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, objetivoList);
            }
            return objetivoList;
        }
    }
}
