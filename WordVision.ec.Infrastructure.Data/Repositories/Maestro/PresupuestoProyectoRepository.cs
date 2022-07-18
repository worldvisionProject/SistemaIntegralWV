using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Maestro
{
    public class PresupuestoProyectoRepository : IPresupuestoProyectoRepository
    {
        private readonly IRepositoryAsync<PresupuestoProyecto> _repository;
        public PresupuestoProyectoRepository(IRepositoryAsync<PresupuestoProyecto> repository)
        {
            _repository = repository;
        }

        public async Task<PresupuestoProyecto> GetByIdAsync(int id)
        {
            return await _repository.Entities.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PresupuestoProyecto>> GetListAsync(PresupuestoProyecto presupuesto)
        {
            IQueryable<PresupuestoProyecto> list = _repository.Entities;

            if (presupuesto.Include)
            {
                list = list.Include(p => p.ProgramaArea).Include(e => e.Estado);
            }

            return await list.ToListAsync();
        }

        public async Task<int> InsertAsync(PresupuestoProyecto presupuesto)
        {
            await _repository.AddAsync(presupuesto);
            return presupuesto.Id;
        }

        public async Task UpdateAsync(PresupuestoProyecto presupuesto)
        {
            await _repository.UpdateAsync(presupuesto);
        }

        public async Task DeleteAsync(PresupuestoProyecto presupuesto)
        {
            await _repository.DeleteAsync(presupuesto);
        }
    }
}
