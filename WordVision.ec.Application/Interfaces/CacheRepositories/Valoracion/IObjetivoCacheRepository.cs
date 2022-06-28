using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion
{
    public interface IObjetivoCacheRepository
    {
        Task<List<Objetivo>> GetCachedListAsync();

        Task<Objetivo> GetByIdAsync(int objetivoId); 
        Task<List<Objetivo>> GetCachedListxAnioFiscalAsync(int idAnioFiscal);
    }
}
