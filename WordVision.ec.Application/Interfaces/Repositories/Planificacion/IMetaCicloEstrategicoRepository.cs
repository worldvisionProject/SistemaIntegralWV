using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IMetaCicloEstrategicoRepository
    {
        IQueryable<MetaCicloEstrategico> MetaCicloEstrategicos { get; }

        Task<List<MetaCicloEstrategico>> GetListAsync();
        Task<List<MetaCicloEstrategico>> GetListxIndicadorAsync(int idIndicador);
        Task<MetaCicloEstrategico> GetByIdAsync(int id);
        Task<int> InsertAsync(MetaCicloEstrategico entidad);

        Task UpdateAsync(MetaCicloEstrategico entidad);

        Task DeleteAsync(MetaCicloEstrategico entidad);
    }
}
