using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Infrastructure.Data.Repositories.Presupuesto
{
    public class DatosT5Repository : IDatosT5Repository
    {
        private readonly IRepositoryAsync<DatosT5> _repository;
        private readonly IDistributedCache _distributedCache;

        public DatosT5Repository(IDistributedCache distributedCache, IRepositoryAsync<DatosT5> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<DatosT5> DatosT5s => _repository.Entities;

        public async Task DeleteAsync(DatosT5 datosT5)
        {
            await _repository.DeleteAsync(datosT5);
        }

        public async Task<DatosT5> GetByIdAsync(int datosT5Id)
        {
            return await _repository.Entities.Where(p => p.Id == datosT5Id).FirstOrDefaultAsync();
        }

        public async Task<List<DatosT5>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(DatosT5 datosT5)
        {
            await _repository.AddAsync(datosT5);

            return datosT5.Id;
        }

        public async Task UpdateAsync(DatosT5 datosT5)
        {
            await _repository.UpdateAsync(datosT5);
        }
    }
}
