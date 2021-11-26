using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Infrastructure.Data.Repositories.Soporte
{
    public class PonenteRepository : IPonenteRepository
    {
        private readonly IRepositoryAsync<Ponente> _repository;
        private readonly IDistributedCache _distributedCache;

        public IQueryable<Ponente> Ponentes => _repository.Entities;

        public PonenteRepository(IRepositoryAsync<Ponente> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public async Task DeleteAsync(Ponente ponente)
        {
            await _repository.DeleteAsync(ponente);
        }

        public async Task<List<Ponente>> GetListAsync(int IdComunicacion)
        {
            return await _repository.Entities.Where(x => x.IdComunicacion == IdComunicacion).ToListAsync();
        }

        public async Task<Ponente> GetByIdAsync(int idPonente)
        {
            return await _repository.Entities.Where(x => x.Id == idPonente).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(Ponente ponente)
        {
            await _repository.AddAsync(ponente);
            return ponente.Id;
        }

        public async Task UpdateAsync(Ponente ponente)
        {
            await _repository.UpdateAsync(ponente);
        }
    }
}
