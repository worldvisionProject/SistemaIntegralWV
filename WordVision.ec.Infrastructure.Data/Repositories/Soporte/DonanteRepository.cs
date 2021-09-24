using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Infrastructure.Data.Repositories.Soporte
{



    public class DonanteRepository : IDonanteRepository

    {

        private readonly IRepositoryAsync<Donante> _repository;
        private readonly IDistributedCache _distributedCache;

        public DonanteRepository(IRepositoryAsync<Donante> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }

        public IQueryable<Donante> donantes => _repository.Entities;
       

        public async Task DeleteAsync(Donante donante)
        {
            await _repository.DeleteAsync(donante);
        }


        public async Task<Donante> GetDonantesAsync(int idDonante)
        {
            return await _repository.Entities.Where(x => x.Id == idDonante).FirstOrDefaultAsync();
        }

        public async Task<List<Donante>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Donante donante)
        {
            await _repository.AddAsync(donante);
            return donante.Id;
        }

        public async Task UpdateAsync(Donante donante)
        {
            await _repository.UpdateAsync(donante);
        }

        public async Task<Donante> GetByIdAsync(int idDonante)
        {
            return await _repository.Entities.Where(x => x.Id == idDonante).FirstOrDefaultAsync();
        }
    }
}
