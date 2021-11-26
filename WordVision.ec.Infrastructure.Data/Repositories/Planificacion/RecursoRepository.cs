using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class SeguimientoRepository : ISeguimientoRepository
    {
        private readonly IRepositoryAsync<Seguimiento> _repository;
        private readonly IDistributedCache _distributedCache;

        public SeguimientoRepository(IDistributedCache distributedCache, IRepositoryAsync<Seguimiento> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Seguimiento> Seguimientoes => _repository.Entities;

        public IQueryable<Seguimiento> Seguimientos => throw new NotImplementedException();

        public async Task DeleteAsync(Seguimiento Seguimiento)
        {
            await _repository.DeleteAsync(Seguimiento);
        }

        public async Task<Seguimiento> GetByIdAsync(int SeguimientoId)
        {
            return await _repository.Entities.Where(p => p.Id == SeguimientoId).FirstOrDefaultAsync();
        }

        public async Task<List<Seguimiento>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Seguimiento>> GetListByIdicadorAsync(int idIndicador, string tipoSeguimiento)
        {
            return await _repository.Entities.Where(p => p.IdIndicador == idIndicador && p.Tipo == tipoSeguimiento).ToListAsync();
        }

        public async Task<int> InsertAsync(Seguimiento Seguimiento)
        {
            await _repository.AddAsync(Seguimiento);
            return Seguimiento.Id;
        }

        public async Task UpdateAsync(Seguimiento Seguimiento)
        {
            await _repository.UpdateAsync(Seguimiento);
        }
    }
}
