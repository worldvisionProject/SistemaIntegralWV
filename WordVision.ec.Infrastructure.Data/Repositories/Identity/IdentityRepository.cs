using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Identity;
using WordVision.ec.Domain.Entities.Identity;

namespace WordVision.ec.Infrastructure.Data.Repositories.Identity
{
    class IdentityRepository : IIdentityRepository
    {
        private readonly IRepositoryAdAsync<UsuariosActiveDirectory> _repository;
        private readonly IDistributedCache _distributedCache;

        public IdentityRepository(IDistributedCache distributedCache, IRepositoryAdAsync<UsuariosActiveDirectory> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<UsuariosActiveDirectory> UsuariosActiveDirectory => _repository.Entities;

        public async Task<UsuariosActiveDirectory> GetByIdAsync(string usuarioId)
        {
            return await _repository.Entities.Where(p => p.UserNameRegular == usuarioId).FirstOrDefaultAsync();
        }

        public async Task<List<UsuariosActiveDirectory>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task UpdateAsync(UsuariosActiveDirectory usuario)
        {
            await _repository.UpdateAsync(usuario);
        
        }
    }
}
