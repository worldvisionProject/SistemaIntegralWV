using Microsoft.EntityFrameworkCore;
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
    public class AvanceObjetivoRepository : IAvanceObjetivoRepository
    {
        private readonly IRepositoryAsync<AvanceObjetivo> _repository;
        public AvanceObjetivoRepository(IRepositoryAsync<AvanceObjetivo> repository)
        {
            _repository = repository;
        }
        public IQueryable<AvanceObjetivo> avanceObjetivo => _repository.Entities;

        public async Task DeleteAsync(AvanceObjetivo avanceObjetivo)
        {
            await _repository.DeleteAsync(avanceObjetivo);
        }

        public async Task<AvanceObjetivo> GetByIdAsync(int avanceObjetivoId)
        {
            return await _repository.Entities.Where(x => x.Id == avanceObjetivoId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<AvanceObjetivo>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<AvanceObjetivo>> GetListxPlanificacionAsync(int idPlanificacionResultado)
        {
            return await _repository.Entities.Where(x => x.IdPlanificacion == idPlanificacionResultado).ToListAsync();
        }

        public async Task<int> InsertAsync(AvanceObjetivo avanceObjetivo)
        {
            await _repository.AddAsync(avanceObjetivo);
            return avanceObjetivo.Id;
        }

        public async Task UpdateAsync(AvanceObjetivo avanceObjetivo)
        {
            await _repository.UpdateAsync(avanceObjetivo);
        }
    }
}
