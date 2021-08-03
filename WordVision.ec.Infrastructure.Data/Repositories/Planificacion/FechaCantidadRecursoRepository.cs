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
    public class FechaCantidadRecursoRepository : IFechaCantidadRecursoRepository
    {
        private readonly IRepositoryAsync<FechaCantidadRecurso> _repository;
        private readonly IDistributedCache _distributedCache;

        public FechaCantidadRecursoRepository(IDistributedCache distributedCache, IRepositoryAsync<FechaCantidadRecurso> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
      
        public IQueryable<FechaCantidadRecurso> FechaCantidadRecursos => _repository.Entities;

        public async Task DeleteAsync(FechaCantidadRecurso fechaCantidadRecurso)
        {
            await _repository.DeleteAsync(fechaCantidadRecurso);
        }

        public async Task<FechaCantidadRecurso> GetByIdAsync(int fechaCantidadRecursoId)
        {
            return await _repository.Entities.Where(p => p.Id == fechaCantidadRecursoId).FirstOrDefaultAsync();
        }

        public async Task<List<FechaCantidadRecurso>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<FechaCantidadRecurso>> GetListByIdAsync(int idRecurso)
        {
            return await _repository.Entities.Where(x => x.IdRecurso == idRecurso).ToListAsync();
        }

        public async Task<int> InsertAsync(FechaCantidadRecurso fechaCantidadRecurso)
        {
            await _repository.AddAsync(fechaCantidadRecurso);
            return fechaCantidadRecurso.Id;
        }

        public async Task UpdateAsync(FechaCantidadRecurso fechaCantidadRecurso)
        {
            await _repository.UpdateAsync(fechaCantidadRecurso);
        }
    }
}
