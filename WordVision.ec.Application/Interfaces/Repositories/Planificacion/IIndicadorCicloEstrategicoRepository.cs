using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorCicloEstrategicoRepository
    {
        IQueryable<IndicadorCicloEstrategico> IndicadorCicloEstrategicos { get; }

        Task<List<IndicadorCicloEstrategico>> GetListAsync();
        Task<List<IndicadorCicloEstrategico>> GetListxEstrategiaAsync(int idEstrategia);
        Task<IndicadorCicloEstrategico> GetByIdAsync(int id);
        Task<int> InsertAsync(IndicadorCicloEstrategico entidad);

        Task UpdateAsync(IndicadorCicloEstrategico entidad);

        Task DeleteAsync(IndicadorCicloEstrategico entidad);
    }
}
