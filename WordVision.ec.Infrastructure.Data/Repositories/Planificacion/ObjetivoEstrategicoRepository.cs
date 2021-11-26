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
    public class ObjetivoEstrategicoRepository : IObjetivoEstrategicoRepository
    {
        private readonly IRepositoryAsync<ObjetivoEstrategico> _repository;
        private readonly IDistributedCache _distributedCache;

        public ObjetivoEstrategicoRepository(IDistributedCache distributedCache, IRepositoryAsync<ObjetivoEstrategico> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<ObjetivoEstrategico> ObjetivoEstrategicoes => _repository.Entities;

        public async Task DeleteAsync(ObjetivoEstrategico ObjetivoEstrategico)
        {
            await _repository.DeleteAsync(ObjetivoEstrategico);
        }

        public async Task<ObjetivoEstrategico> GetByIdAsync(int ObjetivoEstrategicoId)
        {
            return await _repository.Entities.Where(p => p.Id == ObjetivoEstrategicoId)
                .Include(p1 => p1.ProductoObjetivos)
                .Include(x => x.FactorCriticoExitos).FirstOrDefaultAsync();
        }

        public async Task<List<ObjetivoEstrategico>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(ObjetivoEstrategico ObjetivoEstrategico)
        {
            await _repository.AddAsync(ObjetivoEstrategico);
            return ObjetivoEstrategico.Id;
        }

        public async Task UpdateAsync(ObjetivoEstrategico ObjetivoEstrategico)
        {
            await _repository.UpdateAsync(ObjetivoEstrategico);
        }
    }
}
