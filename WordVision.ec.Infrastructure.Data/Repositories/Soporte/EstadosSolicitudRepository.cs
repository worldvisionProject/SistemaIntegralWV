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
    public class EstadosSolicitudRepository : IEstadosSolicitudRepository
    {
        private readonly IRepositoryAsync<EstadosSolicitud> _repository;
        private readonly IDistributedCache _distributedCache;


        public EstadosSolicitudRepository(IRepositoryAsync<EstadosSolicitud> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
        }
        public IQueryable<EstadosSolicitud> estadosSolicitudes => throw new NotImplementedException();

        public async Task DeleteAsync(EstadosSolicitud estadosSolicitud)
        {
            await _repository.DeleteAsync(estadosSolicitud);
        }

        public async Task<List<EstadosSolicitud>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<EstadosSolicitud>> GetSolicitudAsync(int idEstadosSolicitud)
        {
            return await _repository.Entities.Where(x => x.Estado == idEstadosSolicitud).ToListAsync();
        }

     
        public async Task<int> InsertAsync(EstadosSolicitud estadosSolicitud)
        {
            await _repository.AddAsync(estadosSolicitud);
            return estadosSolicitud.Id;
        }

        public async Task UpdateAsync(EstadosSolicitud estadosSolicitud)
        {
            await _repository.UpdateAsync(estadosSolicitud);
        }

       
    }
}
