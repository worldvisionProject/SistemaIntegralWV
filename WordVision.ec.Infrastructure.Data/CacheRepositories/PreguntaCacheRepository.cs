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
    public class PreguntaCacheRepository : IPreguntaCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IPreguntaRepository _PreguntaRepository;

        public PreguntaCacheRepository(IDistributedCache distributedCache, IPreguntaRepository PreguntaRepository)
        {
            _distributedCache = distributedCache;
            _PreguntaRepository = PreguntaRepository;
        }
        public async Task<Pregunta> GetByIdAsync(int PreguntaId)
        {
            string cacheKey = PreguntaCacheKeys.GetKey(PreguntaId);
            var Pregunta = await _distributedCache.GetAsync<Pregunta>(cacheKey);
            if (Pregunta == null)
            {
                Pregunta = await _PreguntaRepository.GetByIdAsync(PreguntaId);
                Throw.Exception.IfNull(Pregunta, "Pregunta", "No Pregunta Found");
                await _distributedCache.SetAsync(cacheKey, Pregunta);
            }
            return Pregunta;
        }

        public async Task<List<Pregunta>> GetByIdDocumentoAsync(int documentoId)
        {
           var pregunta = await _PreguntaRepository.GetByIdDocumentoAsync(documentoId);
            //    await _distributedCache.SetAsync(cacheKey, Pregunta);
            //}
            return pregunta;
        }

        public async Task<List<Pregunta>> GetCachedListAsync()
        {
            string cacheKey = PreguntaCacheKeys.ListKey;
            var PreguntaList = await _distributedCache.GetAsync<List<Pregunta>>(cacheKey);
            if (PreguntaList == null)
            {
                PreguntaList = await _PreguntaRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, PreguntaList);
            }
            return PreguntaList;
        }
    }
}
