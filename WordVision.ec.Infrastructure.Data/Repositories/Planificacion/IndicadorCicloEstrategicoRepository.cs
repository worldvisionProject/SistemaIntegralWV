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
    public class IndicadorCicloEstrategicoRepository : IIndicadorCicloEstrategicoRepository
    {
        private readonly IRepositoryAsync<IndicadorCicloEstrategico> _repository;
        private readonly IDistributedCache _distributedCache;

        public IndicadorCicloEstrategicoRepository(IDistributedCache distributedCache, IRepositoryAsync<IndicadorCicloEstrategico> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<IndicadorCicloEstrategico> IndicadorCicloEstrategicos => _repository.Entities;

        public async Task DeleteAsync(IndicadorCicloEstrategico entidad)
        {
            await _repository.DeleteAsync(entidad);
        }

        public async Task<IndicadorCicloEstrategico> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorCicloEstrategico>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<IndicadorCicloEstrategico>> GetListxEstrategiaAsync(int idEstrategia)
        {
            return await _repository.Entities.Where(p => p.IdEstrategia == idEstrategia).ToListAsync();
        }

        public async Task<int> InsertAsync(IndicadorCicloEstrategico entidad)
        {
            await _repository.AddAsync(entidad);
            return entidad.Id;
        }

        public async Task UpdateAsync(IndicadorCicloEstrategico entidad)
        {
            await _repository.UpdateAsync(entidad);
        }
    }
}
