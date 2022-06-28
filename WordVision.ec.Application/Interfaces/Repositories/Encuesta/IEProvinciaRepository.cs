using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;


namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEProvinciaRepository
    {
        IQueryable<EProvincia> EProvincias { get; }

        Task<List<EProvincia>> GetListAsync();
        Task<EProvincia> GetByIdAsync(string idEProvincia);

        Task<string> InsertAsync(EProvincia eProvincia);
        Task UpdateAsync(EProvincia eProvincia);
        Task DeleteAsync(EProvincia eProvincia);


    }
}
