using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEProgramaIndicadorRepository
    {
        IQueryable<EProgramaIndicador> EProgramaIndicadores { get; }

        Task<List<EProgramaIndicador>> GetListAsync(bool incluir);
        Task<EProgramaIndicador> GetByIdAsync(int idEProgramaIndicador);

        Task<int> InsertAsync(EProgramaIndicador eProgramaIndicador);
        Task UpdateAsync(EProgramaIndicador eProgramaIndicador);
        Task DeleteAsync(EProgramaIndicador eProgramaIndicador);
    }
}
