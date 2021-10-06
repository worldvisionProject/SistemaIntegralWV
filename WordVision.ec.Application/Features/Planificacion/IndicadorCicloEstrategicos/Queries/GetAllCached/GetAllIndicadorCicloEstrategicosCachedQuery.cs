using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WordVision.ec.Application.Features.Planificacion.(Entidad)s.Queries.GetAllCached
{
    public class GetAll(Entidad)sCachedQuery : IRequest<Result<List<GetAll(Entidad)sCachedResponse>>>
    {
    }

    public class GetAll(Entidad)sCachedQueryHandler : IRequestHandler<GetAll(Entidad)sCachedQuery, Result<List<GetAll(Entidad)sCachedResponse>>>
    {
        private readonly I(Entidad)Repository _entidadCache;
        private readonly IMapper _mapper;
     
        public GetAll(Entidad)sCachedQueryHandler(I(Entidad)Repository entidadCache, IMapper mapper)
        {
            _entidadCache = entidadCache;
            _mapper = mapper;
        
        }

        public async Task<Result<List<GetAll(Entidad)sCachedResponse>>> Handle(GetAll(Entidad)sCachedQuery request, CancellationToken cancellationToken)
        {
            var objList = await _entidadCache.GetListAsync();
            var mappedObj = _mapper.Map<List<GetAll(Entidad)sCachedResponse>>(objList);

            return Result<List<GetAll(Entidad)sCachedResponse>>.Success(mappedObj);
        }
    }
}
