using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Soporte;

namespace WordVision.ec.Infrastructure.Data.Repositories.Soporte
{
    public class SolicitudRepository : ISolicitudRepository
    {

        private readonly IRepositoryAsync<Solicitud> _repository;
        private readonly IDistributedCache _distributedCache;
        public SolicitudRepository(IRepositoryAsync<Solicitud> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }

        public IQueryable<Solicitud> solicitudes => _repository.Entities;



        public async Task DeleteAsync(Solicitud solicitud)
        {
           await _repository.DeleteAsync(solicitud);
        }

        public async Task<List<Solicitud>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Solicitud>> GetListSolicitudxAsignadoAsync(int idAsignadoA)
        {
            return await _repository.Entities.Where(x=>x.AsignadoA== idAsignadoA).ToListAsync();
        }

        public async Task<Solicitud> GetSolicitudAsync(int idSolicitud)
        {
            return await _repository.Entities.Where(x => x.Id == idSolicitud).FirstOrDefaultAsync();
        }

        public async Task<int> InsertAsync(Solicitud solicitud)
        {
              await _repository.AddAsync(solicitud);
            return solicitud.Id;
        }

        public async Task UpdateAsync(Solicitud solicitud)
        {
            await _repository.UpdateAsync(solicitud);
        }
    }
}
