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
    public class GestionRepository : IGestionRepository
    {
        private readonly IRepositoryAsync<Gestion> _repository;
        private readonly IDistributedCache _distributedCache;

        public GestionRepository(IDistributedCache distributedCache, IRepositoryAsync<Gestion> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Gestion> Gestiones => _repository.Entities;

        public async Task DeleteAsync(Gestion Gestion)
        {
            await _repository.DeleteAsync(Gestion);
        }

        public async Task<Gestion> GetByIdAsync(int GestionId)
        {
            return await _repository.Entities.Where(p => p.Id == GestionId).FirstOrDefaultAsync();
        }

        public async Task<List<Gestion>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Gestion>> GetListByIdAsync(int idEstrategia)
        {
            return await _repository.Entities.Where(p => p.IdEstrategia == idEstrategia).ToListAsync();
        }

        public async Task<int> InsertAsync(Gestion Gestion)
        {
            await _repository.AddAsync(Gestion);
            return Gestion.Id;
        }

        public async Task UpdateAsync(Gestion Gestion)
        {
            await _repository.UpdateAsync(Gestion);
        }
    }
}
