using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEComunidadRepository
    {
        IQueryable<EComunidad> EComunidades { get; }

        Task<List<EComunidad>> GetListAsync(bool incluir);
        Task<List<EComunidad>> GetListAsync(bool incluir, string padre);

        Task<EComunidad> GetByIdAsync(string idEComunidad);

        Task<string> InsertAsync(EComunidad eComunidad);
        Task UpdateAsync(EComunidad eComunidad);
        Task DeleteAsync(EComunidad eComunidad);


    }
}
