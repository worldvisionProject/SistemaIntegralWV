using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IEstructuraRepository
    {
        IQueryable<Estructura> Estructuras { get; }

        Task<List<Estructura>> GetListAsync();

        Task<Estructura> GetByIdAsync(int id);
   
        Task<int> InsertAsync(Estructura estructura);

        Task UpdateAsync(Estructura estructura);

        Task DeleteAsync(Estructura estructura);
    }
}
