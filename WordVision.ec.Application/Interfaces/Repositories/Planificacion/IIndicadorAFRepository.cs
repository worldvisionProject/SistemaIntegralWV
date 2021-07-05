using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorAFRepository
    {
        IQueryable<IndicadorAF> IndicadorAFes { get; }

        Task<List<IndicadorAF>> GetListAsync();

        Task<IndicadorAF> GetByIdAsync(int indicadorAFId);
      
        Task<int> InsertAsync(IndicadorAF indicadorAF);

        Task UpdateAsync(IndicadorAF indicadorAF);

        Task DeleteAsync(IndicadorAF indicadorAF);
    }
}
