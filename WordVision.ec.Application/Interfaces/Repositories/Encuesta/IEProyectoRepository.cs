using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEProyectoRepository
    {
        IQueryable<EProyecto> EProyectos { get; }

        Task<List<EProyecto>> GetListAsync(bool incluir);
        Task<EProyecto> GetByIdAsync(int idEProyecto);

        Task<int> InsertAsync(EProyecto eProyecto);
        Task UpdateAsync(EProyecto eProyecto);
        Task DeleteAsync(EProyecto eProyecto);
    }
}
