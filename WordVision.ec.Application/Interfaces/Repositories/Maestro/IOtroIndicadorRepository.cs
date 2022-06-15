using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IOtroIndicadorRepository
    {
        Task<OtroIndicador> GetByIdAsync(int id);
        Task<List<OtroIndicador>> GetListAsync(OtroIndicador indicador);
        Task<int> InsertAsync(OtroIndicador indicador);
        Task UpdateAsync(OtroIndicador indicador);
    }
}
