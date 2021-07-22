
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetAllCached;

using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.CacheRepositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Queries.GetAllCached
{
    public class GetAllIndicadorPOAsCachedQuery : IRequest<Result<List<GetAllIndicadorPOAsCachedResponse>>>
    {
        public GetAllIndicadorPOAsCachedQuery()
        {
        }
    }

    public class GetAllIndicadorPOAsCachedQueryHandler : IRequestHandler<GetAllIndicadorPOAsCachedQuery, Result<List<GetAllIndicadorPOAsCachedResponse>>>
    {
        private readonly IIndicadorPOARepository _IndicadorPOACache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllIndicadorPOAsCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IIndicadorPOARepository IndicadorPOACache, IMapper mapper)
        {
            _IndicadorPOACache = IndicadorPOACache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllIndicadorPOAsCachedResponse>>> Handle(GetAllIndicadorPOAsCachedQuery request, CancellationToken cancellationToken)
        {
            var IndicadorPOAList = await _IndicadorPOACache.GetListAsync();
            var mappedIndicadorPOAs = _mapper.Map<List<GetAllIndicadorPOAsCachedResponse>>(IndicadorPOAList);
           
            return Result<List<GetAllIndicadorPOAsCachedResponse>>.Success(mappedIndicadorPOAs);
        }
    }
}