using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IObjetivoEstrategicoRepository
    {
        IQueryable<ObjetivoEstrategico> ObjetivoEstrategicoes { get; }

        Task<List<ObjetivoEstrategico>> GetListAsync();
        Task<List<ObjetivoEstrategico>> GetNacionalAsync();

        Task<ObjetivoEstrategico> GetByIdAsync(int objetivoEstrategicoId);

        Task<int> InsertAsync(ObjetivoEstrategico objetivoEstrategico);

        Task UpdateAsync(ObjetivoEstrategico objetivoEstrategico);

        Task DeleteAsync(ObjetivoEstrategico objetivoEstrategico);
    }
}
