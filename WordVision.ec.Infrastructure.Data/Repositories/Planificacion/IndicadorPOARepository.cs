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
    public class IndicadorPOARepository : IIndicadorPOARepository
    {
        private readonly IRepositoryAsync<IndicadorPOA> _repository;
        private readonly IDistributedCache _distributedCache;

        public IndicadorPOARepository(IDistributedCache distributedCache, IRepositoryAsync<IndicadorPOA> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<IndicadorPOA> IndicadorPOAs => _repository.Entities;

        public async Task DeleteAsync(IndicadorPOA indicadorPOA)
        {
            await _repository.DeleteAsync(indicadorPOA);
        }

        public async Task<IndicadorPOA> GetByIdAsync(int indicadorPOAId)
        {
            return await _repository.Entities.Where(p => p.Id == indicadorPOAId).Include(x => x.MetaTacticas)
                .Include(y => y.Actividades)
                .ThenInclude(r=>r.Recursos)
                .FirstOrDefaultAsync();
        }

        public async Task<List<IndicadorPOA>> GetListAsync()
        {
            return await _repository.Entities.Include(p => p.MetaTacticas).ToListAsync();
        }

        public async Task<int> InsertAsync(IndicadorPOA indicadorPOA)
        {
            await _repository.AddAsync(indicadorPOA);
            return indicadorPOA.Id;
        }

        public async Task UpdateAsync(IndicadorPOA indicadorPOA)
        {
            await _repository.UpdateAsync(indicadorPOA);
        }
    }
}
