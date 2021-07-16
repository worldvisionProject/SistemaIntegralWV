using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IMetaEstrategicaRepository
    {
        IQueryable<MetaEstrategica> MetaEstrategicas { get; }

        Task<List<MetaEstrategica>> GetListAsync();

        Task<MetaEstrategica> GetByIdAsync(int metaEstrategicaId);
        Task<List<MetaEstrategica>> GetListByIdAsync(int idIndicador);
        Task<int> InsertAsync(MetaEstrategica metaEstrategica);

        Task UpdateAsync(MetaEstrategica metaEstrategica);

        Task DeleteAsync(MetaEstrategica metaEstrategica);
    }
}
