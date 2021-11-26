
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetAllCached
{
    public class GetAllGestionesCachedQuery : IRequest<Result<List<GetAllGestionesCachedResponse>>>
    {
        public GetAllGestionesCachedQuery()
        {
        }
    }

    public class GetAllGestionesCachedQueryHandler : IRequestHandler<GetAllGestionesCachedQuery, Result<List<GetAllGestionesCachedResponse>>>
    {
        private readonly IGestionCacheRepository _GestionCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllGestionesCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IGestionCacheRepository GestionCache, IMapper mapper)
        {
            _GestionCache = GestionCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllGestionesCachedResponse>>> Handle(GetAllGestionesCachedQuery request, CancellationToken cancellationToken)
        {
            var GestionList = await _GestionCache.GetCachedListAsync();
            var mappedGestiones = _mapper.Map<List<GetAllGestionesCachedResponse>>(GestionList);

            return Result<List<GetAllGestionesCachedResponse>>.Success(mappedGestiones);
        }
    }
}