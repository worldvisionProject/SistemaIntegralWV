using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetAllCached
{
    public class GetAllCatalogosCachedQuery : IRequest<Result<List<GetAllCatalogosCachedResponse>>>
    {
        public string IdRol { get; set; }
        public GetAllCatalogosCachedQuery()
        {
        }
    }

    public class GetAllCatalogosCachedQueryHandler : IRequestHandler<GetAllCatalogosCachedQuery, Result<List<GetAllCatalogosCachedResponse>>>
    {
        private readonly ICatalogoCacheRepository _CatalogosCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllCatalogosCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, ICatalogoCacheRepository CatalogosCache, IMapper mapper)
        {
            _CatalogosCache = CatalogosCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllCatalogosCachedResponse>>> Handle(GetAllCatalogosCachedQuery request, CancellationToken cancellationToken)
        {
            var CatalogosList = await _CatalogosCache.GetCachedListAsync(request.IdRol);
            var mappedCatalogos = _mapper.Map<List<GetAllCatalogosCachedResponse>>(CatalogosList);
            
            return Result<List<GetAllCatalogosCachedResponse>>.Success(mappedCatalogos);
        }
    }

}
