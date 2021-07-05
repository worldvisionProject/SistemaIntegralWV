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
    public class FormularioCacheRepository : IFormularioCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IFormularioRepository _FormularioRepository;

        public FormularioCacheRepository(IDistributedCache distributedCache, IFormularioRepository FormularioRepository)
        {
            _distributedCache = distributedCache;
            _FormularioRepository = FormularioRepository;
        }
        public async Task<Formulario> GetByIdAsync(int FormularioId)
        {
            string cacheKey = FormularioCacheKeys.GetKey(FormularioId);
            var Formulario = await _distributedCache.GetAsync<Formulario>(cacheKey);
            if (Formulario == null)
            {
                Formulario = await _FormularioRepository.GetByIdAsync(FormularioId);
                Throw.Exception.IfNull(Formulario, "Formulario", "No Formulario Found");
                await _distributedCache.SetAsync(cacheKey, Formulario);
            }
            return Formulario;
        }

        public async Task<List<Formulario>> GetCachedListAsync()
        {
            string cacheKey = FormularioCacheKeys.ListKey;
            var FormularioList = await _distributedCache.GetAsync<List<Formulario>>(cacheKey);
            if (FormularioList == null)
            {
                FormularioList = await _FormularioRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, FormularioList);
            }
            return FormularioList;
        }
    }
}
