using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Maestro
{
    public interface IEstructuraCacheRepository
    {
        Task<List<Estructura>> GetCachedListAsync();

        Task<Estructura> GetByIdAsync(int id);
    }
}
