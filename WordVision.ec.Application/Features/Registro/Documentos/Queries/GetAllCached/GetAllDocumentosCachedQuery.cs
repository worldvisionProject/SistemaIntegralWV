
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Documentos.Queries.GetAllCached
{
    public class GetAllDocumentosCachedQuery : IRequest<Result<List<GetAllDocumentosCachedResponse>>>
    {
        public GetAllDocumentosCachedQuery()
        {
        }
    }

    public class GetAllDocumentosCachedQueryHandler : IRequestHandler<GetAllDocumentosCachedQuery, Result<List<GetAllDocumentosCachedResponse>>>
    {
        private readonly IDocumentoCacheRepository _documentoCache;
        private readonly IMapper _mapper;

        public GetAllDocumentosCachedQueryHandler(IDocumentoCacheRepository documentoCache, IMapper mapper)
        {
            _documentoCache = documentoCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDocumentosCachedResponse>>> Handle(GetAllDocumentosCachedQuery request, CancellationToken cancellationToken)
        {
            var ColaboradorList = await _documentoCache.GetCachedListAsync();
            var mappedDocumentos = _mapper.Map<List<GetAllDocumentosCachedResponse>>(ColaboradorList);
            return Result<List<GetAllDocumentosCachedResponse>>.Success(mappedDocumentos);
        }
    }
}