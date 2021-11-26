using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;

namespace WordVision.ec.Application.Features.Presupuesto.Presupuesto.Queries.GetAllCached
{
    public class GetAllPresupuestosCachedQuery : IRequest<Result<List<GetAllPresupuestosCachedResponse>>>
    {
        public class GetAllPresupuestosCachedQueryHandler : IRequestHandler<GetAllPresupuestosCachedQuery, Result<List<GetAllPresupuestosCachedResponse>>>
        {
            private readonly IPresupuestoRepository _PresupuestoCache;
            private readonly IMapper _mapper;

            public GetAllPresupuestosCachedQueryHandler(IPresupuestoRepository presupuestoCache, IMapper mapper)
            {
                _PresupuestoCache = presupuestoCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetAllPresupuestosCachedResponse>>> Handle(GetAllPresupuestosCachedQuery request, CancellationToken cancellationToken)
            {
                var presupuestoList = await _PresupuestoCache.GetListAsync();
                var mappedPresupuesto = _mapper.Map<List<GetAllPresupuestosCachedResponse>>(presupuestoList);
                return Result<List<GetAllPresupuestosCachedResponse>>.Success(mappedPresupuesto);
            }
        }
    }
}
