using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetAllCached
{
    public class GetAllObjetivosCachedQuery : IRequest<Result<List<GetAllObjetivosCachedResponse>>>
    {
        public GetAllObjetivosCachedQuery()
        {
        }
    }

    public class GetAllObjetivosCachedQueryHandler : IRequestHandler<GetAllObjetivosCachedQuery, Result<List<GetAllObjetivosCachedResponse>>>
    {
        private readonly IObjetivoCacheRepository _objetivoCache;
        private readonly IMapper _mapper;
        private readonly IObjetivoRepository _objetivoRepository;
      

        public GetAllObjetivosCachedQueryHandler(IObjetivoRepository objetivoRepository, IObjetivoCacheRepository objetivoCache, IMapper mapper)
        {
            _objetivoCache = objetivoCache;
            _mapper = mapper;
            _objetivoRepository = objetivoRepository;
        }

       

        public async Task<Result<List<GetAllObjetivosCachedResponse>>> Handle(GetAllObjetivosCachedQuery request, CancellationToken cancellationToken)
        {
            var objetivoList = await _objetivoCache.GetCachedListAsync();
            var mappedColaboradores = _mapper.Map<List<GetAllObjetivosCachedResponse>>(objetivoList);

            return Result<List<GetAllObjetivosCachedResponse>>.Success(mappedColaboradores);
        }
    }
}
