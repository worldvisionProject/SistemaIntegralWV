using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEIndicadorRepository
    {
        IQueryable<EIndicador> EIndicadores { get; }

        Task<List<EIndicador>> GetListAsync();
        Task<EIndicador> GetByIdAsync(string idEIndicador);

        Task<string> InsertAsync(EIndicador eIndicador);
        Task UpdateAsync(EIndicador eIndicador);
        Task DeleteAsync(EIndicador eIndicador);


    }
}
