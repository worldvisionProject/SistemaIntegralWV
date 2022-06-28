using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;


namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IECantonRepository
    {
        IQueryable<ECanton> ECantones { get; }

        Task<List<ECanton>> GetListAsync();
        Task<ECanton> GetByIdAsync(string idECanton);

        Task<string> InsertAsync(ECanton eCanton);
        Task UpdateAsync(ECanton eCanton);
        Task DeleteAsync(ECanton eCanton);


    }
}
