using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;
using WordVision.ec.Infrastructure.Data.CacheKeys.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly IRepositoryAsync<Catalogo> _repository;
        private readonly IRepositoryAsync<DetalleCatalogo> _repositoryDetalle;
        private readonly IDistributedCache _distributedCache;

        public CatalogoRepository(IDistributedCache distributedCache, IRepositoryAsync<Catalogo> repository, IRepositoryAsync<DetalleCatalogo> repositoryDetalle)
        {
            _distributedCache = distributedCache;
            _repositoryDetalle = repositoryDetalle;
            _repository = repository;
        }

        public IQueryable<Catalogo> Catalogos => _repository.Entities;

        public async Task DeleteAsync(Catalogo Catalogo)
        {
            await _repository.DeleteAsync(Catalogo);
            await _distributedCache.RemoveAsync(CatalogoCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CatalogoCacheKeys.GetKey(Catalogo.Id));
        }

        public async Task<Catalogo> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).Include(c => c.DetalleCatalogos).FirstOrDefaultAsync();
        }

        public async Task<DetalleCatalogo> GetDetalleByIdAsync(int id, string secuencia)
        {
            return await _repositoryDetalle.Entities.Where(p => p.IdCatalogo==id && p.Secuencia == secuencia).FirstOrDefaultAsync();

        }

        public async Task<List<DetalleCatalogo>> GetDetalleByIdCatalogoAsync(int id)
        {
            return await _repositoryDetalle.Entities.Where(p => p.IdCatalogo == id ).ToListAsync();

        }

        public async Task<List<Catalogo>> GetListAsync()
        {
            return await _repository.Entities.Where(p => p.Estado == 1).ToListAsync();
        }

        public async Task<int> InsertAsync(Catalogo Catalogo)
        {
            await _repository.AddAsync(Catalogo);

            foreach (var detail in Catalogo.DetalleCatalogos)
            {
                var detailBudget = new DetalleCatalogo
                {
                    Nombre = detail.Nombre,
                    Estado=detail.Estado,
                    Secuencia=detail.Secuencia,
                    IdCatalogo=Catalogo.Id
                };
              await  _repositoryDetalle.AddAsync(detailBudget);
            }

           
            await _distributedCache.RemoveAsync(CatalogoCacheKeys.ListKey);
            return Catalogo.Id;
        }

        public async Task UpdateAsync(Catalogo Catalogo)
        {
            await _repository.UpdateAsync(Catalogo);
            await _distributedCache.RemoveAsync(CatalogoCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CatalogoCacheKeys.GetKey(Catalogo.Id));
        }
    }
}
