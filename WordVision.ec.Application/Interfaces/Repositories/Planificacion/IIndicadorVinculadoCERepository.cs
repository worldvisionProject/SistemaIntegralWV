using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorVinculadoCERepository
    {
        IQueryable<IndicadorVinculadoCE> IndicadorVinculadoCEs { get; }
        Task<IndicadorVinculadoCE> GetByIdAsync(int indicadorVinculadoCEId);
        Task DeleteAsync(IndicadorVinculadoCE indicadorVinculadoCE);
    }
}
