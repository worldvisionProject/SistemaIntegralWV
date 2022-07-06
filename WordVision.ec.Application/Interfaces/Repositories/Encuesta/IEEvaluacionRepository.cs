using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEEvaluacionRepository
    {
        IQueryable<EEvaluacion> EEvaluaciones { get; }

        Task<List<EEvaluacion>> GetListAsync(bool incluir);
        Task<EEvaluacion> GetByIdAsync(int idEEvaluacion);

        Task<int> InsertAsync(EEvaluacion eEvaluacion);
        Task UpdateAsync(EEvaluacion eEvaluacion);
        Task DeleteAsync(EEvaluacion eEvaluacion);
    }
}
