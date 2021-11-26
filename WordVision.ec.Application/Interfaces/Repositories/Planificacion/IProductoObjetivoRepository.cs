using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IProductoObjetivoRepository
    {
        IQueryable<ProductoObjetivo> ProductoObjetivos { get; }

        Task<List<ProductoObjetivo>> GetListAsync();
        Task<ProductoObjetivo> GetByIdAsync(int id);
        Task<List<ProductoObjetivo>> GetByIdObjetivoAsync(int idObjetivo);
        Task<int> InsertAsync(ProductoObjetivo entidad);

        Task UpdateAsync(ProductoObjetivo entidad);

        Task DeleteAsync(ProductoObjetivo entidad);
    }
}
