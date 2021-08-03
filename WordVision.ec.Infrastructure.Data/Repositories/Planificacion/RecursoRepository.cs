using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Planificacion
{
    public class RecursoRepository : IRecursoRepository
    {
        private readonly IRepositoryAsync<Recurso> _repository;
        private readonly IDistributedCache _distributedCache;

        public RecursoRepository(IDistributedCache distributedCache, IRepositoryAsync<Recurso> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Recurso> Recursoes => _repository.Entities;

        public async Task DeleteAsync(Recurso recurso)
        {
            await _repository.DeleteAsync(recurso);
        }

        public async Task<Recurso> GetByIdAsync(int recursoId)
        {
            return await _repository.Entities.Where(p => p.Id == recursoId).Include(f=>f.FechaCantidadRecursos).FirstOrDefaultAsync();
        }

        public async Task<List<Recurso>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Recurso>> GetListByIdAsync(int idActividad)
        {
            return await _repository.Entities.Where(x => x.IdActividad == idActividad).ToListAsync();
        }

        public async Task<int> InsertAsync(Recurso recurso)
        {
            await _repository.AddAsync(recurso);
            return recurso.Id;
        }

        public async Task UpdateAsync(Recurso recurso)
        {
            await _repository.UpdateAsync(recurso);
        }
    }
}
