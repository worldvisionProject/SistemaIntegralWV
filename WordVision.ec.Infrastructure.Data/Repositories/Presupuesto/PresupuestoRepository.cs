using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Presupuesto
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly IRepositoryAsync<Domain.Entities.Presupuesto.Presupuesto> _repository;
        private readonly IDistributedCache _distributedCache;

        public PresupuestoRepository(IDistributedCache distributedCache, IRepositoryAsync<Domain.Entities.Presupuesto.Presupuesto> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Domain.Entities.Presupuesto.Presupuesto> Presupuestos => _repository.Entities;

        public async Task DeleteAsync(Domain.Entities.Presupuesto.Presupuesto presupuesto)
        {
            await _repository.DeleteAsync(presupuesto);
        }

        public async Task<Domain.Entities.Presupuesto.Presupuesto> GetByIdAsync(int presupuestoId)
        {
            return await _repository.Entities.Where(p => p.Id == presupuestoId).FirstOrDefaultAsync();
        }

        public async Task<List<Domain.Entities.Presupuesto.Presupuesto>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Domain.Entities.Presupuesto.Presupuesto presupuesto)
        {
            await _repository.AddAsync(presupuesto);
            return presupuesto.Id;
        }

        public async Task UpdateAsync(Domain.Entities.Presupuesto.Presupuesto presupuesto)
        {
            await _repository.UpdateAsync(presupuesto);
        }
    }
}
