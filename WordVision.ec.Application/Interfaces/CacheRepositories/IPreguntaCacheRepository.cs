using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.CacheRepositories
{
    public interface IPreguntaCacheRepository
    {
        Task<List<Pregunta>> GetCachedListAsync();

        Task<Pregunta> GetByIdAsync(int preguntaId);
        Task<List<Pregunta>> GetByIdDocumentoAsync(int documentoId);
    }
}
