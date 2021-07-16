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
    public class MetaEstrategicaRepository : IMetaEstrategicaRepository
    {
        private readonly IRepositoryAsync<MetaEstrategica> _repository;
        private readonly IDistributedCache _distributedCache;

        public MetaEstrategicaRepository(IDistributedCache distributedCache, IRepositoryAsync<MetaEstrategica> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<MetaEstrategica> MetaEstrategicas => _repository.Entities;

        public async Task DeleteAsync(MetaEstrategica metaEstrategica)
        {
            await _repository.DeleteAsync(metaEstrategica);
        }

        public async Task<MetaEstrategica> GetByIdAsync(int metaEstrategicaId)
        {
            return await _repository.Entities.Where(p => p.Id == metaEstrategicaId).FirstOrDefaultAsync();
        }

        public async Task<List<MetaEstrategica>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<MetaEstrategica>> GetListByIdAsync(int idIndicador)
        {
            return await _repository.Entities.Where(p=>p.IdIndicadorEstrategico== idIndicador).ToListAsync();
        }

        public async Task<int> InsertAsync(MetaEstrategica metaEstrategica)
        {
            await _repository.AddAsync(metaEstrategica);
            return metaEstrategica.Id;
        }

        public async Task UpdateAsync(MetaEstrategica metaEstrategica)
        {
            await _repository.UpdateAsync(metaEstrategica);
        }
    }
}
