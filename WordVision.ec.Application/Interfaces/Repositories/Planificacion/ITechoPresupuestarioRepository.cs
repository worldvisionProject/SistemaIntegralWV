using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface ITechoPresupuestarioRepository
    {
        IQueryable<TechoPresupuestario> TechoPresupuestarios { get; }

        Task<List<TechoPresupuestario>> GetListAsync();
        Task<TechoPresupuestario> GetByIdAsync(int techoPresupuestarioId);
        Task<TechoPresupuestario> GetByIdxCentroAsync(string centroId);
        Task<int> InsertAsync(TechoPresupuestario techoPresupuestario);

        Task UpdateAsync(TechoPresupuestario techoPresupuestario);

        Task DeleteAsync(TechoPresupuestario techoPresupuestario);
    }
}
