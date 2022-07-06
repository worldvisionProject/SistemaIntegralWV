using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEObjetivoRepository
    {
        IQueryable<EObjetivo> EObjetivos { get; }

        Task<List<EObjetivo>> GetListAsync(bool incluir);
        Task<EObjetivo> GetByIdAsync(string idEObjetivo);

        Task<string> InsertAsync(EObjetivo eObjetivo);
        Task UpdateAsync(EObjetivo eObjetivo);
        Task DeleteAsync(EObjetivo eObjetivo);
    }
}
