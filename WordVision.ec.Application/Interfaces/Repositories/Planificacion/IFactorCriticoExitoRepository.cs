using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IFactorCriticoExitoRepository
    {
        IQueryable<FactorCriticoExito> FactorCriticoExitoes { get; }

        Task<List<FactorCriticoExito>> GetListAsync();
        Task<List<FactorCriticoExito>> GetListxObjetivoAsync(int idObjetivo, int idGestion);

        Task<List<FactorCriticoExito>> GetListxObjetivoAsync(int idObjetivo, int idColaborador, int idGestion);
        Task<FactorCriticoExito> GetByIdAsync(int factorCriticoExitoId);

        Task<int> InsertAsync(FactorCriticoExito factorCriticoExito);

        Task UpdateAsync(FactorCriticoExito factorCriticoExito);

        Task DeleteAsync(FactorCriticoExito factorCriticoExito);
    }
}
