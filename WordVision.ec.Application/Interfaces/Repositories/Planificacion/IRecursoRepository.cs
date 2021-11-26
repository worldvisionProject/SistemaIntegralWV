using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IRecursoRepository
    {
        IQueryable<Recurso> Recursoes { get; }

        Task<List<Recurso>> GetListAsync();

        Task<Recurso> GetByIdAsync(int recursoId);
        Task<List<Recurso>> GetListByIdAsync(int idActividad);
        Task<int> InsertAsync(Recurso Recurso);

        Task UpdateAsync(Recurso Recurso);

        Task DeleteAsync(Recurso Recurso);
    }
}
