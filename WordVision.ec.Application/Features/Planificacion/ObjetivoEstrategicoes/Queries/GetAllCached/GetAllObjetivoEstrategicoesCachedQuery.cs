
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

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetAllCached
{
    public class GetAllObjetivoEstrategicoesCachedQuery : IRequest<Result<List<GetAllObjetivoEstrategicoesCachedResponse>>>
    {
        public GetAllObjetivoEstrategicoesCachedQuery()
        {
        }
    }

    public class GetAllObjetivoEstrategicoesCachedQueryHandler : IRequestHandler<GetAllObjetivoEstrategicoesCachedQuery, Result<List<GetAllObjetivoEstrategicoesCachedResponse>>>
    {
        private readonly IObjetivoEstrategicoRepository _ObjetivoEstrategicoCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllObjetivoEstrategicoesCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IObjetivoEstrategicoRepository ObjetivoEstrategicoCache, IMapper mapper)
        {
            _ObjetivoEstrategicoCache = ObjetivoEstrategicoCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllObjetivoEstrategicoesCachedResponse>>> Handle(GetAllObjetivoEstrategicoesCachedQuery request, CancellationToken cancellationToken)
        {
            var ObjetivoEstrategicoList = await _ObjetivoEstrategicoCache.GetListAsync();
            var mappedObjetivoEstrategicoes = _mapper.Map<List<GetAllObjetivoEstrategicoesCachedResponse>>(ObjetivoEstrategicoList);
           
            return Result<List<GetAllObjetivoEstrategicoesCachedResponse>>.Success(mappedObjetivoEstrategicoes);
        }
    }
}