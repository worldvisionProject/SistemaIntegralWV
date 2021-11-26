using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    class RespuestaRepository : IRespuestaRepository
    {
        private readonly IRepositoryAsync<Respuesta> _repository;
        private readonly IDistributedCache _distributedCache;
        public RespuestaRepository(IDistributedCache distributedCache, IRepositoryAsync<Respuesta> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }
        public IQueryable<Respuesta> Respuestas => _repository.Entities;

        public Task DeleteAsync(Respuesta respuesta)
        {
            throw new NotImplementedException();
        }

        public async Task<Respuesta> GetByIdAsync(int respuestaId)
        {
            return await _repository.Entities.Where(p => p.Id == respuestaId).FirstOrDefaultAsync();
        }

        public async Task<Respuesta> GetByIdColaboradorAsync(int colaoradorId, int documentoId, int preguntaId)
        {
            return await _repository.Entities.Where(p => p.IdColaborador == colaoradorId && p.IdDocumento == documentoId && p.IdPregunta == preguntaId).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountByIdColaboradorAsync(int colaoradorId, int documentoId)
        {
            int contar = _repository.Entities.Count(p => p.IdColaborador == colaoradorId && p.IdDocumento == documentoId);
            return contar;
        }

        public async Task<int> GetCountByIdDocumentoAsync(int documentoId)
        {
            int contar = _repository.Entities.Where(p => p.IdDocumento == documentoId).GroupBy(p => p.IdColaborador).Count();
            return contar;
        }

        public async Task<List<Respuesta>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<List<Respuesta>> GetListByIdDocumentoAsync(int documentoId)
        {
            return await _repository.Entities.Where(r => r.IdDocumento == documentoId).ToListAsync();
        }

        public async Task<int> InsertAsync(Respuesta respuesta)
        {
            await _repository.AddAsync(respuesta);
            //await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.ListKey);
            return respuesta.Id;
        }

        public async Task UpdateAsync(Respuesta respuesta)
        {
            await _repository.UpdateAsync(respuesta);
            //await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.ListKey);
            //await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.GetKey(Documento.Id))
        }
    }
}
