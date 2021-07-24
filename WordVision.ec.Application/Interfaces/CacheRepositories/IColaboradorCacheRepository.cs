using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
