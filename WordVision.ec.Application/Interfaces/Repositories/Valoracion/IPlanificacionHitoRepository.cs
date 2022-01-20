using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IPlanificacionHitoRepository
    {
        IQueryable<PlanificacionHito> planificacionHito { get; }

        Task<List<PlanificacionHito>> GetListAsync();
        Task<List<PlanificacionHito>> GetListxPlanificacionAsync(int idPlanificacionResultado);
        Task<PlanificacionHito> GetByIdAsync(int planificacionHitoId);
        Task<int> InsertAsync(PlanificacionHito planificacionHito);

        Task UpdateAsync(PlanificacionHito planificacionHito);

        Task DeleteAsync(PlanificacionHito planificacionHito);
    }
}
