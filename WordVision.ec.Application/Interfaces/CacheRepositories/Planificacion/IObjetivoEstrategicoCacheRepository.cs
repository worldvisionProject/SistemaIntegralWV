using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion
{
    public interface IObjetivoEstrategicoCacheRepository
    {
        Task<List<ObjetivoEstrategico>> GetCachedListAsync();

        Task<ObjetivoEstrategico> GetByIdAsync(int objetivoEstrategicoId);

    }
}
