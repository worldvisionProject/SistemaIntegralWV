using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IPresupuestoProyectoRepository
    {
        Task<PresupuestoProyecto> GetByIdAsync(int id);
        Task<List<PresupuestoProyecto>> GetListAsync(PresupuestoProyecto resupuesto);
        Task<int> InsertAsync(PresupuestoProyecto presupuesto);
        Task UpdateAsync(PresupuestoProyecto presupuesto);
        Task DeleteAsync(PresupuestoProyecto presupuesto);
    }
}
