using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IEReporteDAPRepository
    {
        Task<List<EReporteDAP>> GetListAsync(int EvaluacionId, int RegionId, string ProvinciaId, string CantonId, string ProgramaId, string IndicadorId);
    }
}
