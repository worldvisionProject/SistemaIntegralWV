using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Planificacion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion
{
    public interface IIndicadorAFCacheRepository
    {
        Task<List<IndicadorAF>> GetCachedListAsync();

        Task<IndicadorAF> GetByIdAsync(int indicadorAFId);
       
    }
}
