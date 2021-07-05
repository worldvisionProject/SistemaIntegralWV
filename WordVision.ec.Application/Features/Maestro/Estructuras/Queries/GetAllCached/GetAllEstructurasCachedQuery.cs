using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached;
using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetAllCached
{
    public class GetAllEstructurasCachedQuery : IRequest<Result<List<GetAllEstructurasCachedResponse>>>
    {
    
    }

    public class GetAllEstructurasCachedQueryHandler : IRequestHandler<GetAllEstructurasCachedQuery, Result<List<GetAllEstructurasCachedResponse>>>
    {
        private readonly IEstructuraCacheRepository _ColaboradorCache;
        private readonly IMapper _mapper;
       
        public GetAllEstructurasCachedQueryHandler(IEstructuraCacheRepository ColaboradorCache, IMapper mapper)
        {
            _ColaboradorCache = ColaboradorCache;
            _mapper = mapper;
       
        }

        public async Task<Result<List<GetAllEstructurasCachedResponse>>> Handle(GetAllEstructurasCachedQuery request, CancellationToken cancellationToken)
        {
            var productList = await _ColaboradorCache.GetCachedListAsync();
            var mappedProducts = _mapper.Map<List<GetAllEstructurasCachedResponse>>(productList);
            return Result<List<GetAllEstructurasCachedResponse>>.Success(mappedProducts);
        }
    }
}
