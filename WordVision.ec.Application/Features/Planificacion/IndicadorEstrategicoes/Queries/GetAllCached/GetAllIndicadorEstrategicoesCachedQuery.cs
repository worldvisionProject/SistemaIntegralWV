
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached
{
    public class GetAllIndicadorEstrategicoesCachedQuery : IRequest<Result<List<GetAllIndicadorEstrategicoesCachedResponse>>>
    {
        public GetAllIndicadorEstrategicoesCachedQuery()
        {
        }
    }

    public class GetAllIndicadorEstrategicoesCachedQueryHandler : IRequestHandler<GetAllIndicadorEstrategicoesCachedQuery, Result<List<GetAllIndicadorEstrategicoesCachedResponse>>>
    {
        private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllIndicadorEstrategicoesCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IIndicadorEstrategicoRepository IndicadorEstrategicoCache, IMapper mapper)
        {
            _IndicadorEstrategicoCache = IndicadorEstrategicoCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllIndicadorEstrategicoesCachedResponse>>> Handle(GetAllIndicadorEstrategicoesCachedQuery request, CancellationToken cancellationToken)
        {
            var IndicadorEstrategicoList = await _IndicadorEstrategicoCache.GetListAsync();
            var mappedIndicadorEstrategicoes = _mapper.Map<List<GetAllIndicadorEstrategicoesCachedResponse>>(IndicadorEstrategicoList);
           
            return Result<List<GetAllIndicadorEstrategicoesCachedResponse>>.Success(mappedIndicadorEstrategicoes);
        }
    }
}