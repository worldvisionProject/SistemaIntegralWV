using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Identity;
using WordVision.ec.Application.Interfaces.Repositories.Identity;
using WordVision.ec.Domain.Entities.Identity;
using WordVision.ec.Infrastructure.Data.CacheKeys.Identity;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Identity
{
    public class IdentityCacheRepository : IIdentityCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IIdentityRepository _identityRepository;

        public IdentityCacheRepository(IDistributedCache distributedCache, IIdentityRepository identityRepository)
        {
            _distributedCache = distributedCache;
            _identityRepository = identityRepository;
        }
        public async Task<UsuariosActiveDirectory> GetByIdAsync(string usuarioId)
        {
            //string cacheKey = IdentityCacheKeys.GetKey(usuarioId);
            //var usuario = await _distributedCache.GetAsync<UsuariosActiveDirectory>(cacheKey);
            //if (usuario == null)
            //{
               var  usuario = await _identityRepository.GetByIdAsync(usuarioId);
                Throw.Exception.IfNull(usuario, "Usuario", "Usuario no Encontrado");
              //  await _distributedCache.SetAsync(cacheKey, usuarioId);
            //}
            return usuario;
        }

        public async Task<List<UsuariosActiveDirectory>> GetCachedListAsync()
        {
            string cacheKey = IdentityCacheKeys.ListKey;
            var usuarioList = await _distributedCache.GetAsync<List<UsuariosActiveDirectory>>(cacheKey);
            if (usuarioList == null)
            {
                usuarioList = await _identityRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, usuarioList);
            }
            return usuarioList;
        }
    }
}
