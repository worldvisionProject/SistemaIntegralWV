using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEncuestadoPreguntaKoboRepository
    {
        IQueryable<EncuestadoPreguntaKobo> EncuestadoPreguntaKobos { get; }

        Task<List<EncuestadoPreguntaKobo>> GetListAsyncByEncuestadoKobo(int encuestadoKoboId);
        Task<List<EncuestadoPreguntaKobo>> GetListAsyncByPreguntaKobo(int preguntaKoboId);
        Task<int> InsertAsync(EncuestadoPreguntaKobo encuestadoPreguntaKobo);
        Task DeleteAllAsync(List<EncuestadoPreguntaKobo> encuestadoPreguntaKoboList);

    }
}
