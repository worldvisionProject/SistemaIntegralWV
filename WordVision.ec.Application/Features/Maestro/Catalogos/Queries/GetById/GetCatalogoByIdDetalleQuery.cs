using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById
{
    public class GetCatalogoByIdDetalleQuery : IRequest<Result<string>>
    {
        public int Id { get; set; }
        public string Secuencia { get; set; }
        public class GetCatalogoByIdDetalleQueryHandler : IRequestHandler<GetCatalogoByIdDetalleQuery, Result<string>>
        {
            private readonly ICatalogoCacheRepository _CatalogoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetCatalogoByIdDetalleQueryHandler(ICatalogoCacheRepository CatalogoCache, IMapper mapper)
            {
                _CatalogoCache = CatalogoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<string>> Handle(GetCatalogoByIdDetalleQuery query, CancellationToken cancellationToken)
            {
                var Catalogo = await _CatalogoCache.GetByIdAsync(query.Id);
                string descripcion = Catalogo.DetalleCatalogos.Where(x => x.Secuencia == query.Secuencia).FirstOrDefault().Nombre;

                return Result<string>.Success(descripcion);
            }
        }
    }

}
