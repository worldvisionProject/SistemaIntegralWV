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
    public class MetaCicloEstrategicoRepository : IMetaCicloEstrategicoRepository
    {
        private readonly IRepositoryAsync<MetaCicloEstrategico> _repository;
        private readonly IDistributedCache _distributedCache;

        public MetaCicloEstrategicoRepository(IDistributedCache distributedCache, IRepositoryAsync<MetaCicloEstrategico> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<MetaCicloEstrategico> MetaCicloEstrategicos => _repository.Entities;

        public async Task DeleteAsync(MetaCicloEstrategico entidad)
        {
            await _repository.DeleteAsync(entidad);
        }

        public async Task<MetaCicloEstrategico> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MetaCicloEstrategico>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }


        public async Task<List<MetaCicloEstrategico>> GetListxIndicadorAsync(int idIndicador)
        {
            return await _repository.Entities.Where(p => p.IdIndicadorCicloEstrategico == idIndicador).ToListAsync();

        }

        public async Task<int> InsertAsync(MetaCicloEstrategico entidad)
        {
            await _repository.AddAsync(entidad);
            return entidad.Id;
        }

        public async Task UpdateAsync(MetaCicloEstrategico entidad)
        {
            await _repository.UpdateAsync(entidad);
        }
    }
}
