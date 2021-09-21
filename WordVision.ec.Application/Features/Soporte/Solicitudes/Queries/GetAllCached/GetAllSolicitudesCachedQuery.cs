using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetAllCached
{
    public class GetAllSolicitudesCachedQuery : IRequest<Result<List<GetAllSolicitudesCachedResponse>>>
    {
    }

    public class GetAllSolicitudesCachedQueryHandler : IRequestHandler<GetAllSolicitudesCachedQuery, Result<List<GetAllSolicitudesCachedResponse>>>
    {
        private readonly ISolicitudRepository _entidadCache;
        private readonly IMapper _mapper;
     
        public GetAllSolicitudesCachedQueryHandler(ISolicitudRepository entidadCache, IMapper mapper)
        {
            _entidadCache = entidadCache;
            _mapper = mapper;
        
        }

        public async Task<Result<List<GetAllSolicitudesCachedResponse>>> Handle(GetAllSolicitudesCachedQuery request, CancellationToken cancellationToken)
        {
            var objList = await _entidadCache.GetListAsync();
            var mappedObj = _mapper.Map<List<GetAllSolicitudesCachedResponse>>(objList);

            return Result<List<GetAllSolicitudesCachedResponse>>.Success(mappedObj);
        }
    }
}
