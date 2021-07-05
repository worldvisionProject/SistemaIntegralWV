using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface ICatalogoRepository
    {
        IQueryable<Catalogo> Catalogos { get; }

        Task<List<Catalogo>> GetListAsync();

        Task<Catalogo> GetByIdAsync(int id);

        Task<DetalleCatalogo> GetDetalleByIdAsync(int id,string secuencia);

        Task<List<DetalleCatalogo>> GetDetalleByIdCatalogoAsync(int id);

        Task<int> InsertAsync(Catalogo catalogo);

        Task UpdateAsync(Catalogo catalogo);

        Task DeleteAsync(Catalogo catalogo);
    }
}
