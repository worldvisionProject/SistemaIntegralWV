using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;


namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEReporteTabuladoRepository
    {
        IQueryable<EReporteTabulado> EReporteTabulados { get; }

        Task<List<EReporteTabulado>> GetListAsync(int EvaluacionId, int RegionId, string ProvinciaId, string CantonId, string ProgramaId, string IndicadorId);

        Task<List<ETabulado>> GenerateResultsListAsync(int EvaluacionId);
        Task<List<ETabulado>> GenerateResultsComplejosListAsync(int EvaluacionId);
        Task<List<ETabulado>> GenerateResultsNacionalesListAsync(int EvaluacionId);


        Task<int> InsertAsync(EReporteTabulado eReporteTabulado);

        Task DeleteAllAsync(int EvaluacionId);

    }
}
