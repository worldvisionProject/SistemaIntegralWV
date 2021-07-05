using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Infrastructure.Data.CacheKeys;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories
{
    public class ColaboradorCacheRepository : IColaboradorCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorCacheRepository(IDistributedCache distributedCache, IColaboradorRepository colaboradorRepository)
        {
            _distributedCache = distributedCache;
            _colaboradorRepository = colaboradorRepository;
        }
        public async Task<Colaborador> GetByIdAsync(int colaboradorId)
        {
            string cacheKey = ColaboradorCacheKeys.GetKey(colaboradorId);
            var colaborador = await _distributedCache.GetAsync<Colaborador>(cacheKey);
            if (colaborador == null)
            {
                colaborador = await _colaboradorRepository.GetByIdAsync(colaboradorId);
                Throw.Exception.IfNull(colaborador, "colaborador", "No colaborador Found");
                await _distributedCache.SetAsync(cacheKey, colaborador);
            }
            return colaborador;
        }

        public async Task<Colaborador> GetByIdentificacionAsync(string identificacion)
        {
            //string cacheKey = ColaboradorCacheKeys.GetKey(colaboradorId);
            //var colaborador = await _distributedCache.GetAsync<Colaborador>(cacheKey);
            //if (colaborador == null)
            //{
               var colaborador = await _colaboradorRepository.GetByIdentificacionAsync(identificacion);
                //await _distributedCache.SetAsync(cacheKey, colaborador);
            //}
            return colaborador;
        }

        public async Task<List<Colaborador>> GetCachedListAsync()
        {
            string cacheKey = ColaboradorCacheKeys.ListKey;
            var colaboradorList = await _distributedCache.GetAsync<List<Colaborador>>(cacheKey);
            if (colaboradorList == null)
            {
                colaboradorList = await _colaboradorRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, colaboradorList);
            }
            return colaboradorList;
        }
    }
}
