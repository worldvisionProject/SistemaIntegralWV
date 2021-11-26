using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IFechaCantidadRecursoRepository
    {
        IQueryable<FechaCantidadRecurso> FechaCantidadRecursos { get; }

        Task<List<FechaCantidadRecurso>> GetListAsync();

        Task<FechaCantidadRecurso> GetByIdAsync(int fechaCantidadRecursoId);
        Task<List<FechaCantidadRecurso>> GetListByIdAsync(int idRecurso);
        Task<int> InsertAsync(FechaCantidadRecurso fechaCantidadRecurso);

        Task UpdateAsync(FechaCantidadRecurso fechaCantidadRecurso);

        Task DeleteAsync(FechaCantidadRecurso fechaCantidadRecurso);
    }
}
