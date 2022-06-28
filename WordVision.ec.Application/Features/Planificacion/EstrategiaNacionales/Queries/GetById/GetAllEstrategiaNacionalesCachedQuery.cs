
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById
{
    public class GetAllEstrategiaNacionalesCachedQuery : IRequest<Result<List<GetAllEstrategiaNacionalesCachedResponse>>>
    {
        public GetAllEstrategiaNacionalesCachedQuery()
        {
        }
    }

    public class GetAllEstrategiaNacionalesCachedQueryHandler : IRequestHandler<GetAllEstrategiaNacionalesCachedQuery, Result<List<GetAllEstrategiaNacionalesCachedResponse>>>
    {
        private readonly IEstrategiaNacionalRepository _EstrategiaNacionalCache;
        private readonly ICatalogoRepository _detalleCatalogo;
        private readonly IMapper _mapper;

        private readonly ICatalogoCacheRepository _catalogoCache;


        public GetAllEstrategiaNacionalesCachedQueryHandler(ICatalogoRepository detalleCatalogo, ICatalogoCacheRepository catalogoCache, IEstrategiaNacionalRepository EstrategiaNacionalCache, IMapper mapper)
        {
            _EstrategiaNacionalCache = EstrategiaNacionalCache;
            _mapper = mapper;
            _catalogoCache = catalogoCache;
            _detalleCatalogo = detalleCatalogo;
        }

        public async Task<Result<List<GetAllEstrategiaNacionalesCachedResponse>>> Handle(GetAllEstrategiaNacionalesCachedQuery request, CancellationToken cancellationToken)
        {
            var EstrategiaNacionalList = await _EstrategiaNacionalCache.GetListAsync();
            var mappedEstrategiaNacionales = _mapper.Map<List<GetAllEstrategiaNacionalesCachedResponse>>(EstrategiaNacionalList);
            List<GetAllEstrategiaNacionalesCachedResponse> lista = new List<GetAllEstrategiaNacionalesCachedResponse>();
            for (int i = 0; i <= mappedEstrategiaNacionales.Count - 1; i++)
            {
                //GetAllEstrategiaNacionalesCachedResponse entidad = new GetAllEstrategiaNacionalesCachedResponse();
                var e = _mapper.Map<GetAllEstrategiaNacionalesCachedResponse>(mappedEstrategiaNacionales[i]);
                var c = await _detalleCatalogo.GetDetalleByIdAsync(2, e.Estado);

                e.DescEstado = c.Nombre;
                //List<GetObjetivoEstrategicoByIdResponse> listaO = new List<GetObjetivoEstrategicoByIdResponse>();
                //for (int j = 0; j <= e.ObjetivoEstrategicos.Count - 1; j++)
                //{
                //    var de = _mapper.Map<GetObjetivoEstrategicoByIdResponse>(e.ObjetivoEstrategicos[i]);
                //    var dc = await _detalleCatalogo.GetDetalleByIdAsync(4, de.AreaPrioridad);
                //    de.DescAreaPrioridad = dc.Nombre;
                //    var dc1 = await _detalleCatalogo.GetDetalleByIdAsync(3, de.Dimension);
                //    de.DescDimension = dc1.Nombre;
                //    var dc2 = await _detalleCatalogo.GetDetalleByIdAsync(5, de.Categoria);
                //    de.DescCategoria = dc2.Nombre;


                //}
                lista.Add(e);
            }
            return Result<List<GetAllEstrategiaNacionalesCachedResponse>>.Success(lista);
        }
    }
}