using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Interfaces.Repositories.Registro
{
    public interface IRespuestaRepository
    {
        IQueryable<Respuesta> Respuestas { get; }

        Task<List<Respuesta>> GetListAsync();

        Task<Respuesta> GetByIdAsync(int respuestaId);

        Task<int> GetCountByIdColaboradorAsync(int colaoradorId, int documentoId);

        Task<Respuesta> GetByIdColaboradorAsync(int colaoradorId, int documentoId, int preguntaId);

        Task<List<Respuesta>> GetListByIdDocumentoAsync(int documentoId);
        Task<int> GetCountByIdDocumentoAsync(int documentoId);
        Task<int> InsertAsync(Respuesta respuesta);

        Task UpdateAsync(Respuesta respuesta);

        Task DeleteAsync(Respuesta respuesta);
    }
}
