using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IEstrategiaNacionalRepository
    {
        IQueryable<EstrategiaNacional> EstrategiaNacionales { get; }

        Task<List<EstrategiaNacional>> GetListAsync();

        Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId);

        Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId, int idColaborador);
        Task<EstrategiaNacional> GetByIdxTacticoAsync(int estrategiaNacionalId, int idColaborador, int idReportaA);
        Task<EstrategiaNacional> GetByIdxOperativoAsync(int estrategiaNacionalId, int idColaborador, int idReportaA);

        Task<int> InsertAsync(EstrategiaNacional estrategiaNacional);

        Task UpdateAsync(EstrategiaNacional estrategiaNacional);

        Task DeleteAsync(EstrategiaNacional estrategiaNacional);
    }
}
