using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IProductoRepository
    {
        IQueryable<Producto> Productos { get; }

        Task<List<Producto>> GetListAsync();

        Task<Producto> GetByIdAsync(int productoId, int idColaborador,string idCreadoPor);
        Task<List<Producto>> GetListByIdAsync(int idIndicador);
        Task<List<Producto>> GetListByIdObjetivoAsync(int idObjetivoEstrategico, int idColaborador);
        Task<int> InsertAsync(Producto producto);

        Task UpdateAsync(Producto producto);

        Task DeleteAsync(Producto producto);
    }
}
