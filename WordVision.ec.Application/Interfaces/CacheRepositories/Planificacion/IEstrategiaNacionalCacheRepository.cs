using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion
{
    public interface IEstrategiaNacionalCacheRepository
    {
        Task<List<EstrategiaNacional>> GetCachedListAsync();

        Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId);

    }
}
