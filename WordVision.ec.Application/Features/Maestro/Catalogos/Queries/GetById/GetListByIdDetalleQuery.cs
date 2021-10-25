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
using WordVision.ec.Application.Interfaces.Repositories.Maestro;
using WordVision.ec.Domain.Entities.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById
{
    public class GetListByIdDetalleQuery : IRequest<Result<List<GetListByIdDetalleResponse>>>
    {
        public int Id { get; set; }
        public string Secuencia { get; set; }
        public bool Ninguno { get; set; }
        public class GetListByIdDetalleQueryHandler : IRequestHandler<GetListByIdDetalleQuery, Result<List<GetListByIdDetalleResponse>>>
        { 
            private readonly ICatalogoCacheRepository _CatalogoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetListByIdDetalleQueryHandler(ICatalogoCacheRepository CatalogoCache, IMapper mapper)
            {
                _CatalogoCache = CatalogoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetListByIdDetalleResponse>>> Handle(GetListByIdDetalleQuery query, CancellationToken cancellationToken)
            {
                var Catalogo = await _CatalogoCache.GetDetalleByIdCatalogoAsync(query.Id);
                if (query.Ninguno)
                {
                    var detalle = new DetalleCatalogo();
                    detalle.Secuencia = null;
                    detalle.Nombre = "Seleccione";
                    Catalogo.Insert(0,detalle);
                }    
                var mappedCatalogo = _mapper.Map<List<GetListByIdDetalleResponse>>(Catalogo);
                return Result<List<GetListByIdDetalleResponse>>.Success(mappedCatalogo);
            }
        }
    }

}
