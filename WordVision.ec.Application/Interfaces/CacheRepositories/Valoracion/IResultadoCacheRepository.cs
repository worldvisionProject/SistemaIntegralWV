using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;

namespace WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion
{
    public interface IResultadoCacheRepository
    {
        Task<List<ResultadoResponse>> GetCachedListAsync(int idObjetivoAnioFiscal, int idObjetivo);
        Task<Resultado> GetByIdAsync(int resultadoId);
    }
}
