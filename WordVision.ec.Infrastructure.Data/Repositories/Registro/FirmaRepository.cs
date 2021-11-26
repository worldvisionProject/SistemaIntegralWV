using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    class FirmaRepository : IFirmaRepository
    {
        private readonly IRepositoryAsync<Firma> _repository;
        private readonly IDistributedCache _distributedCache;
        public FirmaRepository(IDistributedCache distributedCache, IRepositoryAsync<Firma> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Firma> Firmas => _repository.Entities;

        public async Task<Firma> GetByIdAsync(int firmaId)
        {
            return await _repository.Entities.Where(p => p.Id == firmaId).Include(x => x.Colaboradores).FirstOrDefaultAsync();

        }

        public async Task<Firma> GetByIdColaboradorAsync(int colaboradorId, int documentoId)
        {
            return await _repository.Entities.Where(p => p.IdColaborador == colaboradorId && p.IdDocumento == documentoId).Include(x => x.Colaboradores).FirstOrDefaultAsync();

        }

        public async Task<List<Firma>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Firma firma)
        {
            await _repository.AddAsync(firma);

            return firma.Id;
        }

        public async Task UpdateAsync(Firma firma)
        {
            await _repository.UpdateAsync(firma);
        }
    }
}
