using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Identity;

namespace WordVision.ec.Application.Features.Identity.Usuarios.Queries.GetAllCached
{
    
        public class GetAllUsuariosCachedQuery : IRequest<Result<List<GetAllUsuariosCachedResponse>>>
        {
            public GetAllUsuariosCachedQuery()
            {
            }
        }

        public class GetAllUsuariosCachedQueryHandler : IRequestHandler<GetAllUsuariosCachedQuery, Result<List<GetAllUsuariosCachedResponse>>>
        {
            private readonly IIdentityCacheRepository _usuarioCache;
            private readonly IMapper _mapper;

            public GetAllUsuariosCachedQueryHandler(IIdentityCacheRepository usuarioCache, IMapper mapper)
            {
                _usuarioCache = usuarioCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetAllUsuariosCachedResponse>>> Handle(GetAllUsuariosCachedQuery request, CancellationToken cancellationToken)
            {
                var usuarioList = await _usuarioCache.GetCachedListAsync();
                var mappedUsuarios = _mapper.Map<List<GetAllUsuariosCachedResponse>>(usuarioList);
                return Result<List<GetAllUsuariosCachedResponse>>.Success(mappedUsuarios);
            }

       
    }

   
}
