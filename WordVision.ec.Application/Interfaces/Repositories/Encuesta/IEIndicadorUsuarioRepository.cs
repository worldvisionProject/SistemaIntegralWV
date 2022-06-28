using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEIndicadorUsuarioRepository
    {
        IQueryable<EIndicadorUsuario> EIndicadorUsuarios { get; }

        Task<List<EIndicadorUsuario>> GetListAsync();
        Task<EIndicadorUsuario> GetByIdAsync(int idEIndicadorUsuario);

        Task<int> InsertAsync(EIndicadorUsuario eIndicadorUsuario);
        Task UpdateAsync(EIndicadorUsuario eIndicadorUsuario);
        Task DeleteAsync(EIndicadorUsuario eIndicadorUsuario);



    }
}
