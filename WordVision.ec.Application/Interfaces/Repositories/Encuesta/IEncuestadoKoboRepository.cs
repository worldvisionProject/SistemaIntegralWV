using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEncuestadoKoboRepository
    {
        IQueryable<EncuestadoKobo> EncuestadoKobos { get; }

        Task<List<EncuestadoKobo>> GetListAsync(int encuestaKoboId);

        Task<EncuestadoKobo> GetByIdAsync(int idEncuestadoKobo);

        Task<int> GetLastIdAsync(int encuestaKoboId);

        Task<int> GetCountAsync(int encuestaKoboId);

        Task<int> InsertAsync(EncuestadoKobo encuestadoKobo);

        Task DeleteAsync(EncuestadoKobo encuestadoKobo);

        Task DeleteAllAsync(List<EncuestadoKobo> encuestadoKoboList);


    }
}
