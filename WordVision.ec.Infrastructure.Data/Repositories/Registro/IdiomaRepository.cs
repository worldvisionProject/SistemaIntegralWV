using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    public class IdiomaRepository : IIdiomaRepository
    {
        private readonly IRepositoryAsync<Idioma> _repository;
        private readonly IDistributedCache _distributedCache;
        public IdiomaRepository(IDistributedCache distributedCache, IRepositoryAsync<Idioma> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Idioma> Idiomas => _repository.Entities;

        public async Task DeleteAsync(Idioma idioma)
        {
            await _repository.DeleteAsync(idioma);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.GetKey(idioma.Id));

        }

        public async Task<Idioma> GetByIdAsync(int idiomaId)
        {
            return await _repository.Entities.Where(p => p.Id == idiomaId).FirstOrDefaultAsync();
        }

        public async Task<List<Idioma>> GetByIdFormularioAsync(int formularioId)
        {
            return await _repository.Entities.Where(p => p.IdFormulario == formularioId).ToListAsync();
        }

        public async Task<List<Idioma>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Idioma idioma)
        {
            await _repository.AddAsync(idioma);
            return idioma.Id;
        }

        public async Task UpdateAsync(Idioma idioma)
        {
            await _repository.UpdateAsync(idioma);
        }
    }
}
