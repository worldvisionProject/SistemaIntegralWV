using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IGestionRepository
    {
        IQueryable<Gestion> Gestiones { get; }

        Task<List<Gestion>> GetListAsync();

        Task<Gestion> GetByIdAsync(int GestionId);
        Task<List<Gestion>> GetListByIdAsync(int idEstrategia);
        Task<int> InsertAsync(Gestion Gestion);

        Task UpdateAsync(Gestion Gestion);

        Task DeleteAsync(Gestion Gestion);
    }
}
