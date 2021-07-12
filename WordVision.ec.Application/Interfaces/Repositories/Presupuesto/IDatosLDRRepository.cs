using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Presupuesto;

namespace WordVision.ec.Application.Interfaces.Repositories.Presupuesto
{
    public interface IDatosLDRRepository
    {
        IQueryable<DatosLDR> DatosLDRs { get; }

        Task<List<DatosLDR>> GetListAsync();

        Task<DatosLDR> GetByIdAsync(int datosLdrId);

        Task<int> InsertAsync(DatosLDR datosLdr);
            Task<int> GetCountAreaAsync(int area);
        Task<int> GetCountNacionalAsync();

        Task UpdateAsync(DatosLDR datosLdr);

        Task DeleteAsync(DatosLDR datosLdr);
    }
}
