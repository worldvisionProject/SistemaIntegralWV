using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;


namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IERegionRepository
    {
        IQueryable<ERegion> ERegiones { get; }

        Task<List<ERegion>> GetListAsync();
        Task<ERegion> GetByIdAsync(int idERegion);

        Task<int> InsertAsync(ERegion eRegion);
        Task UpdateAsync(ERegion eRegion);
        Task DeleteAsync(ERegion eRegion);



    }
}
