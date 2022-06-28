using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Interfaces.Repositories.Encuesta
{
    public interface IETabuladoRepository
    {
        IQueryable<ETabulado> ETabulados { get; }

        Task<List<ETabulado>> GetListAsync(int EvaluacionId, int RegionId, string ProvinciaId, string CantonId, string ParroquiaId, string ComunidadId, string ProgramaId, string IndicadorId);
    }
}
