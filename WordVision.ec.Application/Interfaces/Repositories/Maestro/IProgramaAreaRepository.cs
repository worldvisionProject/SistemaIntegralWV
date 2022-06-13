using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Interfaces.Repositories.Maestro
{
    public interface IProgramaAreaRepository
    {
        Task<ProgramaArea> GetByIdAsync(int id);
        Task<List<ProgramaArea>> GetListAsync(ProgramaArea programaArea);
        Task<int> InsertAsync(ProgramaArea ProgramaArea);
        Task UpdateAsync(ProgramaArea ProgramaArea);
    }
}
