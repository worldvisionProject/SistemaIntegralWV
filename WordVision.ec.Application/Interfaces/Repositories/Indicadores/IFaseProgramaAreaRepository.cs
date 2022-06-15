using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IFaseProgramaAreaRepository
    {
        Task<FaseProgramaArea> GetByIdAsync(int id);
        Task<List<FaseProgramaArea>> GetListAsync(FaseProgramaArea entity);
        Task<int> InsertAsync(FaseProgramaArea entity);
        Task UpdateAsync(FaseProgramaArea entity);
    }
}
