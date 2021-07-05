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
    public class IndicadorAFRepository: IIndicadorAFRepository
    {
        private readonly IRepositoryAsync<IndicadorAF> _repository;
        private readonly IDistributedCache _distributedCache;

        public IndicadorAFRepository(IDistributedCache distributedCache, IRepositoryAsync<IndicadorAF> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<IndicadorAF> IndicadorAFes => _repository.Entities;

        public async Task DeleteAsync(IndicadorAF IndicadorAF)
        {
            await _repository.DeleteAsync(IndicadorAF);
        }

        public async Task<IndicadorAF> GetByIdAsync(int IndicadorAFId)
        {
            return await _repository.Entities.Where(p => p.Id == IndicadorAFId).FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorAF>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(IndicadorAF IndicadorAF)
        {
            await _repository.AddAsync(IndicadorAF);
            return IndicadorAF.Id;
        }

        public async Task UpdateAsync(IndicadorAF IndicadorAF)
        {
            await _repository.UpdateAsync(IndicadorAF);
        }
    }
}
