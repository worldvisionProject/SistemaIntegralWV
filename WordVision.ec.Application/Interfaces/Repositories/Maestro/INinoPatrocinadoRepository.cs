using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface INinoPatrocinadoRepository
    {
        Task<RCNinoPatrocinado> GetByIdAsync(int id);
        Task<List<RCNinoPatrocinado>> GetListAsync();
        Task<int> InsertAsync(RCNinoPatrocinado rCNinoPatrocinado);
        Task UpdateAsync(RCNinoPatrocinado rCNinoPatrocinado);
        Task DeleteAsync(RCNinoPatrocinado rCNinoPatrocinado);
    }
}
