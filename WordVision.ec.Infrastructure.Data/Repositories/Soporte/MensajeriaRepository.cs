using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Infrastructure.Data.Repositories.Soporte
{
    public class MensajeriaRepository : IMensajeriaRepository
    {
        private readonly IRepositoryAsync<WordVision.ec.Domain.Entities.Soporte.Mensajeria> _repository;
        private readonly IDistributedCache _distributedCache;
        public MensajeriaRepository(IRepositoryAsync<WordVision.ec.Domain.Entities.Soporte.Mensajeria> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public IQueryable<Domain.Entities.Soporte.Mensajeria> Mensajeriaes => _repository.Entities;

        public async Task DeleteAsync(Domain.Entities.Soporte.Mensajeria entidad)
        {
            await _repository.DeleteAsync(entidad);
        }

        public async Task<Domain.Entities.Soporte.Mensajeria> GetByIdAsync(int idSolicitud)
        {
            return await _repository.Entities.Where(x => x.Id == idSolicitud).FirstOrDefaultAsync();
        }

        public async Task<List<Domain.Entities.Soporte.Mensajeria>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Domain.Entities.Soporte.Mensajeria entidad)
        {
            await _repository.AddAsync(entidad);
            return entidad.Id;
        }

        public async Task UpdateAsync(Domain.Entities.Soporte.Mensajeria entidad)
        {
            await _repository.UpdateAsync(entidad);
        }
    }
}
