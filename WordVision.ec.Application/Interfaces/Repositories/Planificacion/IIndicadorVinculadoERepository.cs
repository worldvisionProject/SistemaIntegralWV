using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.Repositories.Planificacion
{
    public interface IIndicadorVinculadoERepository
    {
        IQueryable<IndicadorVinculadoE> IndicadorVinculadoEs { get; }
        Task<IndicadorVinculadoE> GetByIdAsync(int indicadorVinculadoEId);
        Task DeleteAsync(IndicadorVinculadoE indicadorVinculadoE);
    }
}
