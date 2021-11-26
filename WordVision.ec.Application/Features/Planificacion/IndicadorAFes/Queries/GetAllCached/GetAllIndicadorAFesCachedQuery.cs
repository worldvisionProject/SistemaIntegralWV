
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Queries.GetAllCached
{
    public class GetAllIndicadorAFesCachedQuery : IRequest<Result<List<GetAllIndicadorAFesCachedResponse>>>
    {
        public GetAllIndicadorAFesCachedQuery()
        {
        }
    }

    public class GetAllIndicadorAFesCachedQueryHandler : IRequestHandler<GetAllIndicadorAFesCachedQuery, Result<List<GetAllIndicadorAFesCachedResponse>>>
    {
        private readonly IIndicadorAFCacheRepository _IndicadorAFCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllIndicadorAFesCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IIndicadorAFCacheRepository IndicadorAFCache, IMapper mapper)
        {
            _IndicadorAFCache = IndicadorAFCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllIndicadorAFesCachedResponse>>> Handle(GetAllIndicadorAFesCachedQuery request, CancellationToken cancellationToken)
        {
            var IndicadorAFList = await _IndicadorAFCache.GetCachedListAsync();
            var mappedIndicadorAFes = _mapper.Map<List<GetAllIndicadorAFesCachedResponse>>(IndicadorAFList);

            return Result<List<GetAllIndicadorAFesCachedResponse>>.Success(mappedIndicadorAFes);
        }
    }
}