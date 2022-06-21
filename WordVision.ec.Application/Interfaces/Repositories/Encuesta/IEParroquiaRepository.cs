using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEParroquiaRepository
    {
        IQueryable<EParroquia> EParroquias { get; }

        Task<List<EParroquia>> GetListAsync();
        Task<EParroquia> GetByIdAsync(string idEParroquia);

        Task<string> InsertAsync(EParroquia eParroquia);
        Task UpdateAsync(EParroquia eParroquia);
        Task DeleteAsync(EParroquia eParroquia);


    }
}
