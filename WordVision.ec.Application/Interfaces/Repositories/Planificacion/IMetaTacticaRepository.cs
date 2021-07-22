using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IMetaTacticaRepository
    {
        IQueryable<MetaTactica> MetaTacticas { get; }

        Task<List<MetaTactica>> GetListAsync();

        Task<MetaTactica> GetByIdAsync(int MetaTacticaId);
        Task<List<MetaTactica>> GetListByIdAsync(int idIndicador);
        Task<int> InsertAsync(MetaTactica MetaTactica);

        Task UpdateAsync(MetaTactica MetaTactica);

        Task DeleteAsync(MetaTactica MetaTactica);
    }
}
