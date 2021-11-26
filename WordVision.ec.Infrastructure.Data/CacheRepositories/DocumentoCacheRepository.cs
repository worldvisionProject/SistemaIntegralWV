using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;
using WordVision.ec.Infrastructure.Data.CacheKeys;

namespace WordVision.ec.Infrastructure.Data.CacheRepositories
{
    public class DocumentoCacheRepository : IDocumentoCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IDocumentoRepository _DocumentoRepository;

        public DocumentoCacheRepository(IDistributedCache distributedCache, IDocumentoRepository DocumentoRepository)
        {
            _distributedCache = distributedCache;
            _DocumentoRepository = DocumentoRepository;
        }
        public async Task<Documento> GetByIdAsync(int DocumentoId)
        {
            //string cacheKey = DocumentoCacheKeys.GetKey(DocumentoId);
            //var Documento = await _distributedCache.GetAsync<Documento>(cacheKey);
            //if (Documento == null)
            //{
            var Documento = await _DocumentoRepository.GetByIdAsync(DocumentoId);
            Throw.Exception.IfNull(Documento, "Documento", "No Documento Found");
            //    await _distributedCache.SetAsync(cacheKey, Documento);
            //}
            return Documento;
        }

        public async Task<List<Documento>> GetCachedListAsync()
        {
            string cacheKey = DocumentoCacheKeys.ListKey;
            var DocumentoList = await _distributedCache.GetAsync<List<Documento>>(cacheKey);
            if (DocumentoList == null)
            {
                DocumentoList = await _DocumentoRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, DocumentoList);
            }
            return DocumentoList;
        }
    }
}
