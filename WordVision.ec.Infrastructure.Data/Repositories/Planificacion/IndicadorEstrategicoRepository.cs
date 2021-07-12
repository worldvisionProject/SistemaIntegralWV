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
    public class IndicadorEstrategicoRepository: IIndicadorEstrategicoRepository
    {
        private readonly IRepositoryAsync<IndicadorEstrategico> _repository;
        private readonly IDistributedCache _distributedCache;

        public IndicadorEstrategicoRepository(IDistributedCache distributedCache, IRepositoryAsync<IndicadorEstrategico> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<IndicadorEstrategico> IndicadorEstrategicoes => _repository.Entities;

        public async Task DeleteAsync(IndicadorEstrategico IndicadorEstrategico)
        {
            await _repository.DeleteAsync(IndicadorEstrategico);
        }

        public async Task<IndicadorEstrategico> GetByIdAsync(int IndicadorEstrategicoId)
        {
            return await _repository.Entities.Where(p => p.Id == IndicadorEstrategicoId).Include(p=>p.IndicadorAFs).FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorEstrategico>> GetListAsync()
        {
            return await _repository.Entities.Include(p => p.IndicadorAFs).ToListAsync();
        }

        public async Task<int> InsertAsync(IndicadorEstrategico IndicadorEstrategico)
        {
            await _repository.AddAsync(IndicadorEstrategico);
            return IndicadorEstrategico.Id;
        }

        public async Task UpdateAsync(IndicadorEstrategico IndicadorEstrategico)
        {
            await _repository.UpdateAsync(IndicadorEstrategico);
        }
    }
}
