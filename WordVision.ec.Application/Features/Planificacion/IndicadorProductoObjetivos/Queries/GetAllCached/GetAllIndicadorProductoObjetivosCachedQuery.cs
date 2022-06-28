using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetAllCached
{
    public class GetAllIndicadorProductoObjetivosCachedQuery : IRequest<Result<List<GetAllIndicadorProductoObjetivosCachedResponse>>>
    {
        public int Id { get; set; }
    }

    public class GetAllIndicadorProductoObjetivosCachedQueryHandler : IRequestHandler<GetAllIndicadorProductoObjetivosCachedQuery, Result<List<GetAllIndicadorProductoObjetivosCachedResponse>>>
    {
        private readonly IIndicadorProductoObjetivoRepository _entidadCache;
        private readonly IMapper _mapper;

        public GetAllIndicadorProductoObjetivosCachedQueryHandler(IIndicadorProductoObjetivoRepository entidadCache, IMapper mapper)
        {
            _entidadCache = entidadCache;
            _mapper = mapper;

        }

        public async Task<Result<List<GetAllIndicadorProductoObjetivosCachedResponse>>> Handle(GetAllIndicadorProductoObjetivosCachedQuery request, CancellationToken cancellationToken)
        {
            var objList = await _entidadCache.GetByIdProductoObjetivoAsync(request.Id);
            var mappedObj = _mapper.Map<List<GetAllIndicadorProductoObjetivosCachedResponse>>(objList);

            return Result<List<GetAllIndicadorProductoObjetivosCachedResponse>>.Success(mappedObj);
        }
    }
}
