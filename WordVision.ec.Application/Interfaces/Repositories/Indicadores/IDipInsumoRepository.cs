using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Indicadores;

namespace WordVision.ec.Application.Interfaces.Repositories.Indicadores
{
    public interface IDipInsumoRepository
    {
        Task<DipInsumo> GetByIdAsync(int id);
        Task<List<DipInsumo>> GetListAsync(DipInsumo entity);
        Task<int> InsertAsync(DipInsumo entity);
        Task UpdateAsync(DipInsumo entity);
    }
}
