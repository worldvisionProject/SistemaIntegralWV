using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Catalogos.Queries.GetById
{
    public class GetCatalogoByIdQuery : IRequest<Result<GetCatalogoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetCatalogoByIdQueryHandler : IRequestHandler<GetCatalogoByIdQuery, Result<GetCatalogoByIdResponse>>
        {
            private readonly ICatalogoRepository _CatalogoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetCatalogoByIdQueryHandler(ICatalogoRepository CatalogoCache, IMapper mapper)
            {
                _CatalogoCache = CatalogoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetCatalogoByIdResponse>> Handle(GetCatalogoByIdQuery query, CancellationToken cancellationToken)
            {
                var Catalogo = await _CatalogoCache.GetByIdAsync(query.Id);
                var mappedCatalogo = _mapper.Map<GetCatalogoByIdResponse>(Catalogo);

                return Result<GetCatalogoByIdResponse>.Success(mappedCatalogo);
            }
        }
    }

}
