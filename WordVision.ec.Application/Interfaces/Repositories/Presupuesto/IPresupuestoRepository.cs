using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Application.Interfaces.Repositories.Presupuesto
{
    public interface IPresupuestoRepository
    {
        IQueryable<Domain.Entities.Presupuesto.Presupuesto> Presupuestos { get; }

        Task<List<Domain.Entities.Presupuesto.Presupuesto>> GetListAsync();

        Task<Domain.Entities.Presupuesto.Presupuesto> GetByIdAsync(int presupuestoId);

        Task<int> InsertAsync(Domain.Entities.Presupuesto.Presupuesto presupuesto);

        Task UpdateAsync(Domain.Entities.Presupuesto.Presupuesto presupuesto);

        Task DeleteAsync(Domain.Entities.Presupuesto.Presupuesto presupuesto);
    }
}
