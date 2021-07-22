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
    public class MetaTacticaRepository : IMetaTacticaRepository
    {
        private readonly IRepositoryAsync<MetaTactica> _repository;
        private readonly IDistributedCache _distributedCache;

        public MetaTacticaRepository(IDistributedCache distributedCache, IRepositoryAsync<MetaTactica> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<MetaTactica> MetaTacticas => _repository.Entities;

        public async Task DeleteAsync(MetaTactica MetaTactica)
        {
            await _repository.DeleteAsync(MetaTactica);
        }

        public async Task<MetaTactica> GetByIdAsync(int MetaTacticaId)
        {
            return await _repository.Entities.Where(p => p.Id == MetaTacticaId).FirstOrDefaultAsync();
        }

        public async Task<List<MetaTactica>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<MetaTactica>> GetListByIdAsync(int idIndicador)
        {
            return await _repository.Entities.Where(p=>p.IdIndicadorPOA== idIndicador).ToListAsync();
        }

        public async Task<int> InsertAsync(MetaTactica MetaTactica)
        {
            await _repository.AddAsync(MetaTactica);
            return MetaTactica.Id;
        }

        public async Task UpdateAsync(MetaTactica MetaTactica)
        {
            await _repository.UpdateAsync(MetaTactica);
        }
    }
}
