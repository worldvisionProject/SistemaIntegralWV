using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEncuestaKoboRepository
    {
        IQueryable<EncuestaKobo> EncuestaKobos { get; }

        Task<List<EncuestaKobo>> GetListAsync();
        Task<EncuestaKobo> GetByIdAsync(int idEncuestaKobo);
        Task<List<EncuestaKobo>> GetKoboAPIAsync(string urlKobo, string usuarioKobo, string claveKobo);


        Task<int> InsertAsync(EncuestaKobo encuestaKobo);
        Task UpdateAsync(EncuestaKobo encuestaKobo);
        Task DeleteAsync(EncuestaKobo encuestaKobo);


    }
}
