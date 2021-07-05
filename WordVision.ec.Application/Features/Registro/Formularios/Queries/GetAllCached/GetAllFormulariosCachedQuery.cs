
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Formularios.Queries.GetAllCached
{
    public class GetAllFormulariosCachedQuery : IRequest<Result<List<GetAllFormulariosCachedResponse>>>
    {
        public GetAllFormulariosCachedQuery()
        {
        }
    }

    public class GetAllFormulariosCachedQueryHandler : IRequestHandler<GetAllFormulariosCachedQuery, Result<List<GetAllFormulariosCachedResponse>>>
    {
        private readonly IFormularioCacheRepository _documentoCache;
        private readonly IMapper _mapper;

        public GetAllFormulariosCachedQueryHandler(IFormularioCacheRepository documentoCache, IMapper mapper)
        {
            _documentoCache = documentoCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllFormulariosCachedResponse>>> Handle(GetAllFormulariosCachedQuery request, CancellationToken cancellationToken)
        {
            var ColaboradorList = await _documentoCache.GetCachedListAsync();
            var mappedFormularios = _mapper.Map<List<GetAllFormulariosCachedResponse>>(ColaboradorList);
            return Result<List<GetAllFormulariosCachedResponse>>.Success(mappedFormularios);
        }
    }
}