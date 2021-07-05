
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetAllCached
{
    public class GetAllColaboradoresCachedQuery : IRequest<Result<List<GetAllColaboradoresCachedResponse>>>
    {
        public GetAllColaboradoresCachedQuery()
        {
        }
    }

    public class GetAllColaboradoresCachedQueryHandler : IRequestHandler<GetAllColaboradoresCachedQuery, Result<List<GetAllColaboradoresCachedResponse>>>
    {
        private readonly IColaboradorCacheRepository _ColaboradorCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllColaboradoresCachedQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IColaboradorCacheRepository ColaboradorCache, IMapper mapper)
        {
            _ColaboradorCache = ColaboradorCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetAllColaboradoresCachedResponse>>> Handle(GetAllColaboradoresCachedQuery request, CancellationToken cancellationToken)
        {
            var ColaboradorList = await _ColaboradorCache.GetCachedListAsync();
            var mappedColaboradores = _mapper.Map<List<GetAllColaboradoresCachedResponse>>(ColaboradorList);
            foreach (var col in mappedColaboradores)
            {
                var formulario = await _formularioCache.GetByIdAsync(col.Id);
                col.ActDatos = formulario == null ? "No" : "Si";
                col.ActDocumentos = await _respuestaCache.GetCountByIdColaboradorAsync(col.Id, 3) == 0 ? "No" : "Si";
                col.ActPoliticas = await _respuestaCache.GetCountByIdColaboradorAsync(col.Id, 4) == 0 ? "No" : "Si";
            }
            return Result<List<GetAllColaboradoresCachedResponse>>.Success(mappedColaboradores);
        }
    }
}