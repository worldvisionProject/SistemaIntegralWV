using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Application.Interfaces.Repositories.Presupuesto
{
    public interface IDatosT5Repository
    {
        IQueryable<DatosT5> DatosT5s { get; }

        Task<List<DatosT5>> GetListAsync();

        Task<DatosT5> GetByIdAsync(int datosT5Id);

        Task<int> InsertAsync(DatosT5 datosT5);

        Task UpdateAsync(DatosT5 datosT5);

        Task DeleteAsync(DatosT5 datosT5);
    }
}
