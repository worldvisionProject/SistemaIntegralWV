using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IPreguntaKoboRepository
    {
        IQueryable<PreguntaKobo> PreguntaKobos { get; }

        Task<List<PreguntaKobo>> GetListAsync(int encuestaKoboId);

        Task<PreguntaKobo> GetByNameAsync(int encuestaKoboId, string nombrePropiedad);

        Task<int> GetCountAsync(int encuestaKoboId);

        Task<int> InsertAsync(PreguntaKobo preguntaKobo);

        Task DeleteAllAsync(List<PreguntaKobo> preguntaKoboList);

    }
}
