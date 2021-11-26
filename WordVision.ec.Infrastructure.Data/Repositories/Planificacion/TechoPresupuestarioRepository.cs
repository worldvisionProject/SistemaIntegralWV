using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class TechoPresupuestarioRepository : ITechoPresupuestarioRepository
    {
        private readonly IRepositoryAsync<TechoPresupuestario> _repository;
        private readonly IDistributedCache _distributedCache;
        public TechoPresupuestarioRepository(IDistributedCache distributedCache, IRepositoryAsync<TechoPresupuestario> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<TechoPresupuestario> TechoPresupuestarios => _repository.Entities;

        public async Task DeleteAsync(TechoPresupuestario techoPresupuestario)
        {
            await _repository.DeleteAsync(techoPresupuestario);
        }

        public async Task<TechoPresupuestario> GetByIdAsync(int techoPresupuestarioId)
        {
            return await _repository.Entities.Where(p => p.Id == techoPresupuestarioId).FirstOrDefaultAsync();
        }

        public async Task<TechoPresupuestario> GetByIdxCentroAsync(string centroId)
        {
            return await _repository.Entities.Where(p => p.CodigoCC == centroId).FirstOrDefaultAsync();

        }

        public async Task<List<TechoPresupuestario>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(TechoPresupuestario techoPresupuestario)
        {
            await _repository.AddAsync(techoPresupuestario);
            return techoPresupuestario.Id;
        }

        public async Task UpdateAsync(TechoPresupuestario techoPresupuestario)
        {
            await _repository.UpdateAsync(techoPresupuestario);
        }
    }
}
