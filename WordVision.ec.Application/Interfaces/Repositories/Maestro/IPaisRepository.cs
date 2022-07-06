using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IPaisRepository
    {
        IQueryable<Pais> paises { get; }

        Task<List<Pais>> GetListAsync();

        Task<Pais> GetByIdAsync(int idPais);
        Task<List<Provincia>> GetByIdRegionAsync(int idRegion);
        Task<List<Ciudad>> GetByIdProvinciaAsync(int idProvincia);
    }
}
