using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion
{
    public interface IFactorCriticoExitoCacheRepository
    {
        Task<List<FactorCriticoExito>> GetCachedListAsync();

        Task<FactorCriticoExito> GetByIdAsync(int factorCriticoExitoId);

    }
}
