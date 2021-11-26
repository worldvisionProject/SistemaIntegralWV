using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly IRepositoryAsync<Colaborador> _repository;
        private readonly IRepositoryAsync<Estructura> _repositoryE;
        private readonly IDistributedCache _distributedCache;

        public ColaboradorRepository(IRepositoryAsync<Estructura> repositoryE, IDistributedCache distributedCache, IRepositoryAsync<Colaborador> repository)
        {
            _distributedCache = distributedCache;
            _repositoryE = repositoryE;
            _repository = repository;
        }

        public IQueryable<Colaborador> Colaboradores => _repository.Entities;

        public async Task DeleteAsync(Colaborador colaborador)
        {
            await _repository.DeleteAsync(colaborador);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.GetKey(colaborador.Id));
        }

        public async Task<Colaborador> GetByEstructuraAsync(int idEstructura)
        {
            return await _repository.Entities.Where(p => p.IdEstructura == idEstructura).FirstOrDefaultAsync();
        }

        public async Task<List<Colaborador>> GetByIdAreaAsync(int idArea)
        {
            return await _repository.Entities.Where(p => p.Area == idArea).ToListAsync();
        }

        public async Task<Colaborador> GetByIdAsync(int colaboradorId)
        {
            return await _repository.Entities.Where(p => p.Id == colaboradorId)
                 .Include(e => e.Estructuras)
                .ThenInclude(em => em.Empresas)
                .Include(f => f.Formularios)
                .ThenInclude(f1 => f1.FormularioTerceros)
                .ThenInclude(f2 => f2.Terceros)
                .FirstOrDefaultAsync();
        }

        public async Task<Colaborador> GetByIdentificacionAsync(string identificacion)
        {
            return await _repository.Entities.Where(p => p.Identificacion == identificacion)
                .Include(e => e.Estructuras)
                .ThenInclude(em => em.Empresas)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Colaborador>> GetByNivelAsync(int nivel1, int nivel2)
        {
            return await _repository.Entities.Where(x => x.Estructuras.Nivel == 1 || x.Estructuras.Nivel == 2 || x.Estructuras.Nivel == nivel1 || x.Estructuras.Nivel == nivel2)
                .IgnoreAutoIncludes().ToListAsync();
        }

        public async Task<Colaborador> GetByUserNameAsync(string username)
        {
            return await _repository.Entities.Where(p => p.Alias == username).Include(e => e.Estructuras)
                .ThenInclude(em => em.Empresas)
                .FirstOrDefaultAsync(); ;
        }

        public async Task<List<Colaborador>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Colaborador colaborador)
        {
            await _repository.AddAsync(colaborador);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            return colaborador.Id;
        }

        public async Task UpdateAsync(Colaborador colaborador)
        {
            await _repository.UpdateAsync(colaborador);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.ColaboradorCacheKeys.GetKey(colaborador.Id));
        }
    }
}
