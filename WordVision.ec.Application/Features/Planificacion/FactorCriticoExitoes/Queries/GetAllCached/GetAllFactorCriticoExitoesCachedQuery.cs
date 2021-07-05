
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

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetAllCached
{
    public class GetAllFactorCriticoExitoesCachedQuery : IRequest<Result<List<GetAllFactorCriticoExitoesCachedResponse>>>
    {
        public GetAllFactorCriticoExitoesCachedQuery()
        {
        }
    }

    public class GetAllFactorCriticoExitoesCachedQueryHandler : IRequestHandler<GetAllFactorCriticoExitoesCachedQuery, Result<List<GetAllFactorCriticoExitoesCachedResponse>>>
    {
        private readonly IFactorCriticoExitoRepository _FactorCriticoExitoCache;
        private readonly IMapper _mapper;
    

        public GetAllFactorCriticoExitoesCachedQueryHandler( IFactorCriticoExitoRepository FactorCriticoExitoCache, IMapper mapper)
        {
            _FactorCriticoExitoCache = FactorCriticoExitoCache;
            _mapper = mapper;
           
        }

        public async Task<Result<List<GetAllFactorCriticoExitoesCachedResponse>>> Handle(GetAllFactorCriticoExitoesCachedQuery request, CancellationToken cancellationToken)
        {
            var FactorCriticoExitoList = await _FactorCriticoExitoCache.GetListAsync();
            var mappedFactorCriticoExitoes = _mapper.Map<List<GetAllFactorCriticoExitoesCachedResponse>>(FactorCriticoExitoList);
            
            return Result<List<GetAllFactorCriticoExitoesCachedResponse>>.Success(mappedFactorCriticoExitoes);
        }
    }
}