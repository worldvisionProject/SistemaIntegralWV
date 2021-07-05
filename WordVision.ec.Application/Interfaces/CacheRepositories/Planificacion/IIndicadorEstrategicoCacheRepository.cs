using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion
{
    public interface IIndicadorEstrategicoCacheRepository
    {
        Task<List<IndicadorEstrategico>> GetCachedListAsync();

        Task<IndicadorEstrategico> GetByIdAsync(int indicadorEstrategico);
       
    }
}
