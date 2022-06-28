using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;
using WordVision.ec.Domain.Entities.Valoracion;
using WordVision.ec.Infrastructure.Data.CacheKeys.Valoracion;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories.Valoracion
{
    public class ResultadoCacheRepository : IResultadoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IResultadoRepository _resultadoRepository;

        public ResultadoCacheRepository(IDistributedCache distributedCache, IResultadoRepository resultadoRepository)
        {
            _distributedCache = distributedCache;
            _resultadoRepository = resultadoRepository;
        }

        public async Task<Resultado> GetByIdAsync(int resultadoId)
        {
            string cacheKey = ResultadoCacheKey.GetKey(resultadoId);
            var resultado = await _distributedCache.GetAsync<Resultado>(cacheKey);
            if (resultado == null)
            {
                resultado = await _resultadoRepository.GetByIdAsync(resultadoId);
                Throw.Exception.IfNull(resultado, "resultado", "No resultado Found");
                await _distributedCache.SetAsync(cacheKey, resultado);
            }
            return resultado;
        }

        public async Task<List<ResultadoResponse>> GetCachedListAsync(int idObjetivoAnioFiscal, int idObjetivo)
        {
            string cacheKey = ResultadoCacheKey.ListKey;
            var resultadoList = await _distributedCache.GetAsync<List<ResultadoResponse>>(cacheKey+ idObjetivoAnioFiscal.ToString()+ idObjetivo.ToString());
            if (resultadoList == null)
            {
                resultadoList = await _resultadoRepository.GetListxAnioAsync(idObjetivoAnioFiscal, idObjetivo);
                await _distributedCache.SetAsync(cacheKey + idObjetivoAnioFiscal.ToString() + idObjetivo.ToString(), resultadoList);
            }
            return resultadoList;
        }
    }
}
