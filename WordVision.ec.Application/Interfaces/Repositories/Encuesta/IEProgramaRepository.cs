using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;
namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEProgramaRepository
    {
        IQueryable<EPrograma> EProgramas { get; }

        Task<List<EPrograma>> GetListAsync(bool incluir);
        Task<EPrograma> GetByIdAsync(string idEPrograma);

        Task<string> InsertAsync(EPrograma ePrograma);
        Task UpdateAsync(EPrograma ePrograma);
        Task DeleteAsync(EPrograma ePrograma);


    }
}
