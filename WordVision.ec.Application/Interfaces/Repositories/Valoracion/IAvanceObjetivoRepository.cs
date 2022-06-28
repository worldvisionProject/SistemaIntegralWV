using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.Repositories.Valoracion
{
    public interface IAvanceObjetivoRepository
    {
        IQueryable<AvanceObjetivo> avanceObjetivo { get; }

        Task<List<AvanceObjetivo>> GetListAsync();
        Task<List<AvanceObjetivo>> GetListxPlanificacionAsync(int idPlanificacionResultado);
        Task<AvanceObjetivo> GetByIdAsync(int avanceObjetivoId);
        Task<int> InsertAsync(AvanceObjetivo avanceObjetivo);

        Task UpdateAsync(AvanceObjetivo avanceObjetivo);

        Task DeleteAsync(AvanceObjetivo avanceObjetivo);
    }
}
