using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Infrastructure.Data.Repositories.Registro
{
    class DocumentoRepository : IDocumentoRepository
    {
        private readonly IRepositoryAsync<Documento> _repository;
        private readonly IRepositoryAsync<Pregunta> _repositoryP;
        private readonly IDistributedCache _distributedCache;
        public DocumentoRepository(IDistributedCache distributedCache, IRepositoryAsync<Documento> repository, IRepositoryAsync<Pregunta> repositoryP)
        {
            _distributedCache = distributedCache;
            _repository = repository;
            _repositoryP = repositoryP;
        }
        public IQueryable<Documento> Documentos => _repository.Entities;

        public async Task DeleteAsync(Documento Documento)
        {
            await _repository.DeleteAsync(Documento);
            await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.GetKey(Documento.Id));
        }

        public async Task<Documento> GetByIdAsync(int DocumentoId)
        {
            return await _repository.Entities.Where(p => p.Id == DocumentoId).Include(x => x.Preguntas).FirstOrDefaultAsync();

            //return await _repository.Entities.Where(p => p.Id == DocumentoId).FirstOrDefaultAsync();
        }

        public async Task<List<Documento>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Documento Documento)
        {
            await _repository.AddAsync(Documento);
            foreach (var oC in Documento.Preguntas)
            {
                await _repositoryP.AddAsync(oC);
            }

            await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.ListKey);
            return Documento.Id;
        }

        public async Task UpdateAsync(Documento Documento)
        {
            await _repository.UpdateAsync(Documento);
            await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.DocumentoCacheKeys.GetKey(Documento.Id));
        }
    }
}
