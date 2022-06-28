using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IPlanificacionComportamientoRepository
    {
        IQueryable<PlanificacionComportamiento> planificacionComportamiento { get; }

        Task<List<PlanificacionComportamiento>> GetListAsync();
        Task<List<PlanificacionComportamiento>> GetListxPlanificacionAsync(int idPlanificacionResultado);
        Task<PlanificacionComportamiento> GetByIdAsync(int idPlanificacionComportamiento);
        Task<int> InsertAsync(PlanificacionComportamiento planificacionComportamiento);

        Task UpdateAsync(PlanificacionComportamiento planificacionComportamiento);

        Task DeleteAsync(PlanificacionComportamiento planificacionComportamiento);
    }
}
