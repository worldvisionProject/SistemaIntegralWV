using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Maestro
{
   public interface ICatalogoCacheRepository
    {
        Task<List<Catalogo>> GetCachedListAsync();

        Task<Catalogo> GetByIdAsync(int id);

        Task<ICollection<DetalleCatalogo>> GetDetalleByIdAsync(int id,string secuencia);

        Task<List<DetalleCatalogo>> GetDetalleByIdCatalogoAsync(int id);
    }
}
