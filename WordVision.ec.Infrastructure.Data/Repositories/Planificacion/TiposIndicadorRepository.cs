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
    public class TiposIndicadorRepository : ITiposIndicadorRepository
    {
        private readonly IRepositoryAsync<TiposIndicador> _repository;
        private readonly IDistributedCache _distributedCache;
        public TiposIndicadorRepository(IDistributedCache distributedCache, IRepositoryAsync<TiposIndicador> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<TiposIndicador> TiposIndicadores => throw new NotImplementedException();

        public Task DeleteAsync(TiposIndicador tiposIndicador)
        {
            throw new NotImplementedException();
        }

        public async Task<TiposIndicador> GetByIdAsync(int idTiposIndicador)
        {
            return await _repository.Entities.Where(p => p.Id == idTiposIndicador).FirstOrDefaultAsync();
        }

        public async Task<List<TiposIndicador>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<TiposIndicador>> GetListxTipoAsync(int idTipo)
        {
            return await _repository.Entities.Where(p => p.CodigoTipoIndicador == idTipo).ToListAsync();
        }

        public Task<int> InsertAsync(TiposIndicador tiposIndicador)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TiposIndicador tiposIndicador)
        {
            throw new NotImplementedException();
        }
    }
}
