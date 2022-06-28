using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface ITiposIndicadorRepository
    {
        IQueryable<TiposIndicador> TiposIndicadores { get; }

        Task<List<TiposIndicador>> GetListAsync();
        Task<List<TiposIndicador>> GetListxTipoAsync(int idTipo);
        Task<TiposIndicador> GetByIdAsync(int idTiposIndicador);
        Task<int> InsertAsync(TiposIndicador tiposIndicador);

        Task UpdateAsync(TiposIndicador tiposIndicador);

        Task DeleteAsync(TiposIndicador tiposIndicador);
    }
}
