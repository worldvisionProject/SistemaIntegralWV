using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorEstrategicoRepository
    {
        IQueryable<IndicadorEstrategico> IndicadorEstrategicoes { get; }

        Task<List<IndicadorEstrategico>> GetListAsync();
        Task<List<IndicadorEstrategico>> GetListxObjetivoAsync(int idObjetivoEstrategico, int idColaborador);
        Task<IndicadorEstrategico> GetByIdAsync(int indicadorEstrategicoId, int idColaborador, string idCreadoPor);

        Task<int> InsertAsync(IndicadorEstrategico indicadorEstrategico);

        Task UpdateAsync(IndicadorEstrategico indicadorEstrategico);

        Task DeleteAsync(IndicadorEstrategico indicadorEstrategico);
    }
}
