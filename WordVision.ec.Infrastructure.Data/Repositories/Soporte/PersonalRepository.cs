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
    public class PersonalRepository : IPersonalRepository
    {
        private readonly IRepositoryAsync<Personal> _repository;
        private readonly IDistributedCache _distributedCache;

        public async Task DeleteAsync(Personal personal)
        {
            await _repository.DeleteAsync(personal);
        }

        public async Task<List<Personal>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<Personal> GetPonenteAsync(int idPersonal)
        {
            return await _repository.Entities.Where(x => x.Id == idPersonal).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(Personal personal)
        {
            await _repository.AddAsync(personal);
            return personal.Id;
        }

        public async Task UpdateAsync(Personal personal)
        {
            await _repository.UpdateAsync(personal);
        }
    }
}
