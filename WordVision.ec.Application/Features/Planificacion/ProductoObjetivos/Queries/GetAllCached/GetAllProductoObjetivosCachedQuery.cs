using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WordVision.ec.Application.Features.Planificacion.ProductoObjetivos.Queries.GetAllCached
{
    public class GetAllProductoObjetivosCachedQuery : IRequest<Result<List<GetAllProductoObjetivosCachedResponse>>>
    {
    }

    public class GetAllProductoObjetivosCachedQueryHandler : IRequestHandler<GetAllProductoObjetivosCachedQuery, Result<List<GetAllProductoObjetivosCachedResponse>>>
    {
        private readonly IProductoObjetivoRepository _entidadCache;
        private readonly IMapper _mapper;
     
        public GetAllProductoObjetivosCachedQueryHandler(IProductoObjetivoRepository entidadCache, IMapper mapper)
        {
            _entidadCache = entidadCache;
            _mapper = mapper;
        
        }

        public async Task<Result<List<GetAllProductoObjetivosCachedResponse>>> Handle(GetAllProductoObjetivosCachedQuery request, CancellationToken cancellationToken)
        {
            var objList = await _entidadCache.GetListAsync();
            var mappedObj = _mapper.Map<List<GetAllProductoObjetivosCachedResponse>>(objList);

            return Result<List<GetAllProductoObjetivosCachedResponse>>.Success(mappedObj);
        }
    }
}
