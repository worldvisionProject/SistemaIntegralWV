using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEMetaRepository
    {
        IQueryable<EMeta> EMetas { get; }

        Task<List<EMeta>> GetListAsync();
        Task<EMeta> GetByIdAsync(int idEMeta);

        Task<int> InsertAsync(EMeta eMeta);
        Task UpdateAsync(EMeta eMeta);
        Task DeleteAsync(EMeta eMeta);
    }
}
