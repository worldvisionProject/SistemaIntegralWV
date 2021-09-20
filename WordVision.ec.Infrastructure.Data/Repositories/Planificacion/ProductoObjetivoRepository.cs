using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class ProductoObjetivoRepository : IProductoObjetivoRepository
    {
        private readonly IRepositoryAsync<ProductoObjetivo> _repository;
        private readonly IDistributedCache _distributedCache;

        public ProductoObjetivoRepository(IDistributedCache distributedCache, IRepositoryAsync<ProductoObjetivo> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<ProductoObjetivo> ProductoObjetivos => _repository.Entities;

        public async Task DeleteAsync(ProductoObjetivo entidad)
        {
            await _repository.DeleteAsync(entidad);
        }

        public async Task<ProductoObjetivo> GetByIdAsync(int id)
        {
           return await _repository.Entities.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProductoObjetivo>> GetByIdObjetivoAsync(int idObjetivo)
        {
            return await _repository.Entities.Where(x => x.IdObjetivoEstra == idObjetivo).ToListAsync();
        }

        public async Task<List<ProductoObjetivo>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(ProductoObjetivo entidad)
        {
            await _repository.AddAsync(entidad);
            return entidad.Id;
        }

        public async Task UpdateAsync(ProductoObjetivo entidad)
        {
            await _repository.UpdateAsync(entidad);
        }
    }
}
