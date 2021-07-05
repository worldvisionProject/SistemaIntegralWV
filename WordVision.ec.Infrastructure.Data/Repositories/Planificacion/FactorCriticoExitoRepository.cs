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
    public class FactorCriticoExitoRepository: IFactorCriticoExitoRepository
    {
        private readonly IRepositoryAsync<FactorCriticoExito> _repository;
        private readonly IDistributedCache _distributedCache;

        public FactorCriticoExitoRepository(IDistributedCache distributedCache, IRepositoryAsync<FactorCriticoExito> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<FactorCriticoExito> FactorCriticoExitoes => _repository.Entities;

        public async Task DeleteAsync(FactorCriticoExito FactorCriticoExito)
        {
            await _repository.DeleteAsync(FactorCriticoExito);
        }

        public async Task<FactorCriticoExito> GetByIdAsync(int FactorCriticoExitoId)
        {
            return await _repository.Entities.Where(p => p.Id == FactorCriticoExitoId).Include(x=>x.IndicadorEstrategicos).FirstOrDefaultAsync();
        }

        public async Task<List<FactorCriticoExito>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(FactorCriticoExito FactorCriticoExito)
        {
            await _repository.AddAsync(FactorCriticoExito);
            return FactorCriticoExito.Id;
        }

        public async Task UpdateAsync(FactorCriticoExito FactorCriticoExito)
        {
            await _repository.UpdateAsync(FactorCriticoExito);
        }
    }
}
