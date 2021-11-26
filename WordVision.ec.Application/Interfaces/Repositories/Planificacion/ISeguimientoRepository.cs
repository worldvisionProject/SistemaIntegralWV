using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface ISeguimientoRepository
    {
        IQueryable<Seguimiento> Seguimientos { get; }

        Task<List<Seguimiento>> GetListAsync();

        Task<Seguimiento> GetByIdAsync(int SeguimientoId);
        Task<List<Seguimiento>> GetListByIdicadorAsync(int idIndicador, string tipoSeguimiento);
        Task<int> InsertAsync(Seguimiento Seguimiento);

        Task UpdateAsync(Seguimiento Seguimiento);

        Task DeleteAsync(Seguimiento Seguimiento);
    }
}
