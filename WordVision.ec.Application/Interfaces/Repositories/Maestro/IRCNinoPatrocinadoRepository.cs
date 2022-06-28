using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IRCNinoPatrocinadoRepository
    {
        Task<RCNinoPatrocinado> GetByIdAsync(int id, bool include = false);
        Task<List<RCNinoPatrocinado>> GetListAsync(RCNinoPatrocinado rCNinoPatrocinado);
        Task<int> InsertAsync(RCNinoPatrocinado rCNinoPatrocinado);
        Task UpdateAsync(RCNinoPatrocinado rCNinoPatrocinado);
    }
}
