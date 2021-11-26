using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorPOARepository
    {
        IQueryable<IndicadorPOA> IndicadorPOAs { get; }

        Task<List<IndicadorPOA>> GetListAsync();

        Task<IndicadorPOA> GetByIdAsync(int indicadorPOAId);

        Task<List<IndicadorPOA>> GetListByIdObjetivoAsync(int idObjetivoEstrategico, int idColaborador);

        Task<int> InsertAsync(IndicadorPOA indicadorPOA);

        Task UpdateAsync(IndicadorPOA indicadorPOA);

        Task DeleteAsync(IndicadorPOA indicadorPOA);
    }
}
