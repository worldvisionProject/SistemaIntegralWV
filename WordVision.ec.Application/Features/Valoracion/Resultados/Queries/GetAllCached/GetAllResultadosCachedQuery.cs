using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Resultados.Queries.GetAllCached
{
    public class GetAllResultadosCachedQuery : IRequest<Result<List<GetAllResultadosCachedResponse>>>
    {
        public int  IdObjetivoAnioFiscal { get; set; }
        public int IdObjetivo { get; set; }
        public GetAllResultadosCachedQuery()
        {
        }
    }


    public class GetAllResultadosCachedQueryHandler : IRequestHandler<GetAllResultadosCachedQuery, Result<List<GetAllResultadosCachedResponse>>>
    {
        private readonly IResultadoCacheRepository _resultadoCache;
        private readonly IMapper _mapper;
        private readonly IResultadoRepository _resultadoRepository;


        public GetAllResultadosCachedQueryHandler(IResultadoRepository resultadoRepository, IResultadoCacheRepository resultadoCache, IMapper mapper)
        {
            _resultadoCache = resultadoCache;
            _mapper = mapper;
            _resultadoRepository = resultadoRepository;
        }

        public async Task<Result<List<GetAllResultadosCachedResponse>>> Handle(GetAllResultadosCachedQuery request, CancellationToken cancellationToken)
        {
            var objetivoList = await _resultadoCache.GetCachedListAsync(request.IdObjetivoAnioFiscal, request.IdObjetivo);
            var mappedResultado = _mapper.Map<List<GetAllResultadosCachedResponse>>(objetivoList);

            return Result<List<GetAllResultadosCachedResponse>>.Success(mappedResultado);
        }
    }


}
