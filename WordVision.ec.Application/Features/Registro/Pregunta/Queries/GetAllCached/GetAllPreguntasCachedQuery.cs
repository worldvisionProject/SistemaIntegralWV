
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetAllCached
{
    public class GetAllPreguntasCachedQuery : IRequest<Result<List<GetAllPreguntasCachedResponse>>>
    {
        public GetAllPreguntasCachedQuery()
        {
        }
    }

    public class GetAllPreguntasCachedQueryHandler : IRequestHandler<GetAllPreguntasCachedQuery, Result<List<GetAllPreguntasCachedResponse>>>
    {
        private readonly IPreguntaCacheRepository _preguntaCache;
        private readonly IMapper _mapper;

        public GetAllPreguntasCachedQueryHandler(IPreguntaCacheRepository preguntaCache, IMapper mapper)
        {
            _preguntaCache = preguntaCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPreguntasCachedResponse>>> Handle(GetAllPreguntasCachedQuery request, CancellationToken cancellationToken)
        {
            var preguntaList = await _preguntaCache.GetCachedListAsync();
            var mappedDocumentos = _mapper.Map<List<GetAllPreguntasCachedResponse>>(preguntaList);
            return Result<List<GetAllPreguntasCachedResponse>>.Success(mappedDocumentos);
        }
    }
}