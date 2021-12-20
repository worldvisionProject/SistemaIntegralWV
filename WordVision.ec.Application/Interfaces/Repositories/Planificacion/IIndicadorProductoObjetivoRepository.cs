using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorProductoObjetivoRepository
    {
        IQueryable<IndicadorProductoObjetivo> IndicadorProductoObjetivos { get; }

        Task<List<IndicadorProductoObjetivo>> GetListAsync();
        Task<IndicadorProductoObjetivo> GetByIdAsync(int id);

        Task<List<IndicadorProductoObjetivo>> GetByIdProductoObjetivoAsync(int idProductoObjetivo);
        Task<int> InsertAsync(IndicadorProductoObjetivo entidad);

        Task UpdateAsync(IndicadorProductoObjetivo entidad);

        Task DeleteAsync(IndicadorProductoObjetivo entidad);
    }
}
