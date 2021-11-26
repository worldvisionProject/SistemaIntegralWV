using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Productos.Queries.GetAllCached
{
    public class GetAllProductosCachedQuery : IRequest<Result<List<GetAllProductosCachedResponse>>>
    {
    }

    public class GetAllProductosCachedQueryHandler : IRequestHandler<GetAllProductosCachedQuery, Result<List<GetAllProductosCachedResponse>>>
    {
        private readonly IProductoRepository _productoCache;
        private readonly IMapper _mapper;

        public GetAllProductosCachedQueryHandler(IProductoRepository productoCache, IMapper mapper)
        {
            _productoCache = productoCache;
            _mapper = mapper;

        }

        public async Task<Result<List<GetAllProductosCachedResponse>>> Handle(GetAllProductosCachedQuery request, CancellationToken cancellationToken)
        {
            var ProductoList = await _productoCache.GetListAsync();
            var mappedProductos = _mapper.Map<List<GetAllProductosCachedResponse>>(ProductoList);

            return Result<List<GetAllProductosCachedResponse>>.Success(mappedProductos);
        }
    }
}
