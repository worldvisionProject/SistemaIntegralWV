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
    public class CatalogoCacheRepository : ICatalogoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICatalogoRepository _CatalogoRepository;
     
        public CatalogoCacheRepository(IDistributedCache distributedCache, ICatalogoRepository CatalogoRepository)
        {
            _distributedCache = distributedCache;
            _CatalogoRepository = CatalogoRepository;
        }
        public async Task<Catalogo> GetByIdAsync(int id)
        {
            string cacheKey = CatalogoCacheKeys.GetKey(id);
            var Catalogo = await _distributedCache.GetAsync<Catalogo>(cacheKey);
            if (Catalogo == null)
            {
                Catalogo = await _CatalogoRepository.GetByIdAsync(id);
                Throw.Exception.IfNull(Catalogo, "Catalogo", "No Catalogo Found");
                await _distributedCache.SetAsync(cacheKey, Catalogo);
            }
            return Catalogo;
        }

        public async Task<List<Catalogo>> GetCachedListAsync(string idRol)
        {
            if (idRol.Length == 0)
            {
                string cacheKey = CatalogoCacheKeys.ListKey;
                var CatalogoList = await _distributedCache.GetAsync<List<Catalogo>>(cacheKey);
                if (CatalogoList == null)
                {
                    CatalogoList = await _CatalogoRepository.GetListAsync(idRol);
                    await _distributedCache.SetAsync(cacheKey, CatalogoList);
                }
                return CatalogoList;
            }
            else
            {
                string cacheKey = CatalogoCacheKeys.ListKey;
                var CatalogoList = await _CatalogoRepository.GetListAsync(idRol);
                await _distributedCache.SetAsync(cacheKey, CatalogoList);
                return CatalogoList;
            }
           
        }

        public async Task<ICollection<DetalleCatalogo>> GetDetalleByIdAsync(int id, string secuencia)
        {
            string cacheKey = CatalogoCacheKeys.GetKey(id);
            var Catalogo = await _distributedCache.GetAsync<Catalogo>(cacheKey);
            if (Catalogo == null)
            {
                Catalogo = await _CatalogoRepository.GetByIdAsync(id);
                Throw.Exception.IfNull(Catalogo, "Catalogo", "No Catalogo Found");
                await _distributedCache.SetAsync(cacheKey, Catalogo);
            }
            return Catalogo.DetalleCatalogos;
        }

        public async Task<List<DetalleCatalogo>> GetDetalleByIdCatalogoAsync(int id)
        {
            string cacheKey = CatalogoCacheKeys.GetDetailsKey(id);
            var Catalogo = await _distributedCache.GetAsync<List<DetalleCatalogo>>(cacheKey);
            if (Catalogo == null || Catalogo.Count==0)
            {
                Catalogo = await _CatalogoRepository.GetDetalleByIdCatalogoAsync(id);
                Throw.Exception.IfNull(Catalogo, "Catalogo", "No Catalogo Found");
                await _distributedCache.SetAsync(cacheKey, Catalogo);
            }
            return Catalogo;
        }
    }
}
