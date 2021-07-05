using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IEstrategiaNacionalRepository
    {
        IQueryable<EstrategiaNacional> EstrategiaNacionales { get; }

        Task<List<EstrategiaNacional>> GetListAsync();

        Task<EstrategiaNacional> GetByIdAsync(int estrategiaNacionalId);
      
        Task<int> InsertAsync(EstrategiaNacional estrategiaNacional);

        Task UpdateAsync(EstrategiaNacional estrategiaNacional);

        Task DeleteAsync(EstrategiaNacional estrategiaNacional);
    }
}
