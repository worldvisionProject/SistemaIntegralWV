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
    public class PlanificacionHitoRepository : IPlanificacionHitoRepository
    {
        private readonly IRepositoryAsync<PlanificacionHito> _repository;
        private readonly IDistributedCache _distributedCache;
        public PlanificacionHitoRepository( IRepositoryAsync<PlanificacionHito> repository, IDistributedCache distributedCache)
        {
            _repository = repository;
            _distributedCache = distributedCache;
         
        }
        public IQueryable<PlanificacionHito> planificacionHito => _repository.Entities;

        public async Task DeleteAsync(PlanificacionHito planificacionHito)
        {
            await _repository.DeleteAsync(planificacionHito);
        }

        public async Task<PlanificacionHito> GetByIdAsync(int planificacionHitoId)
        {
            return await _repository.Entities.Where(x => x.Id == planificacionHitoId)
                .FirstOrDefaultAsync();

        }

        public async Task<List<PlanificacionHito>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<PlanificacionHito>> GetListxPlanificacionAsync(int idPlanificacionResultado)
        {
            return await _repository.Entities.Where(x => x.IdPlanificacion == idPlanificacionResultado).ToListAsync();
        }

        public async Task<int> InsertAsync(PlanificacionHito planificacionHito)
        {
            await _repository.AddAsync(planificacionHito);
            return planificacionHito.Id;
        }

        public async Task UpdateAsync(PlanificacionHito planificacionHito)
        {
            await _repository.UpdateAsync(planificacionHito);
        }
    }
}
