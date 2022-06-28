using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Infrastructure.Data.Repositories.Valoracion
{
    public class PlanificacionComportamientoRepository : IPlanificacionComportamientoRepository
    {
        private readonly IRepositoryAsync<PlanificacionComportamiento> _repository;
        private readonly IDistributedCache _distributedCache;
        public PlanificacionComportamientoRepository( IRepositoryAsync<PlanificacionComportamiento> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
         
        }
        public IQueryable<PlanificacionComportamiento> planificacionComportamiento => _repository.Entities;

        public async Task DeleteAsync(PlanificacionComportamiento planificacionComportamiento)
        {
            await _repository.DeleteAsync(planificacionComportamiento);
        }

        public async Task<PlanificacionComportamiento> GetByIdAsync(int idPlanificacionComportamiento)
        {
            return await _repository.Entities.Where(x => x.Id == idPlanificacionComportamiento)
                .FirstOrDefaultAsync();

        }

        public async Task<List<PlanificacionComportamiento>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<PlanificacionComportamiento>> GetListxPlanificacionAsync(int idPlanificacionResultado)
        {
            return await _repository.Entities.Where(x => x.IdPlanificacion == idPlanificacionResultado).ToListAsync();
        }

        public async Task<int> InsertAsync(PlanificacionComportamiento planificacionComportamiento)
        {
            await _repository.AddAsync(planificacionComportamiento);
            return planificacionComportamiento.Id;
        }

        public async Task UpdateAsync(PlanificacionComportamiento planificacionComportamiento)
        {
            await _repository.UpdateAsync(planificacionComportamiento);
        }
    }
}
