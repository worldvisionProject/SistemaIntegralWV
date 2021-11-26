using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.CacheRepositories
{
    public interface IDocumentoCacheRepository
    {
        Task<List<Documento>> GetCachedListAsync();

        Task<Documento> GetByIdAsync(int DocumentoId);
    }
}
