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
    public class ComunicacionRepository : IComunicacionRepository
    {
        private readonly IRepositoryAsync<WordVision.ec.Domain.Entities.Soporte.Comunicacion> _repository;
        private readonly IDistributedCache _distributedCache;
        public ComunicacionRepository(IRepositoryAsync<WordVision.ec.Domain.Entities.Soporte.Comunicacion> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }

        public IQueryable<Comunicacion> Comunicaciones => _repository.Entities;

        public async Task DeleteAsync(Comunicacion entidad)
        {
            await _repository.DeleteAsync(entidad);
        }

        public async Task<Comunicacion> GetByIdAsync(int idSolicitud)
        {
            return await _repository.Entities.Where(x => x.Id == idSolicitud).FirstOrDefaultAsync();
        }

        public async Task<List<Comunicacion>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Comunicacion entidad)
        {
            await _repository.AddAsync(entidad);
            return entidad.Id;
        }

        public async Task UpdateAsync(Comunicacion entidad)
        {
            await _repository.UpdateAsync(entidad);
        }
    }
}
