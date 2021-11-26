using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.CacheRepositories
{
    public interface IColaboradorCacheRepository
    {
        Task<List<Colaborador>> GetCachedListAsync();

        Task<Colaborador> GetByIdAsync(int colaboradorId);
        Task<Colaborador> GetByIdentificacionAsync(string identificacion);
        Task<Colaborador> GetByUserNameAsync(string username);
        Task<List<Colaborador>> GetByNivelAsync(int nivel1, int nivel2);
        Task<Colaborador> GetByEstructuraAsync(int idEstructura);
    }
}
