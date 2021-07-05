using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorEstrategicoRepository
    {
        IQueryable<IndicadorEstrategico> IndicadorEstrategicoes { get; }

        Task<List<IndicadorEstrategico>> GetListAsync();

        Task<IndicadorEstrategico> GetByIdAsync(int indicadorEstrategicoId);
      
        Task<int> InsertAsync(IndicadorEstrategico indicadorEstrategico);

        Task UpdateAsync(IndicadorEstrategico indicadorEstrategico);

        Task DeleteAsync(IndicadorEstrategico indicadorEstrategico);
    }
}
