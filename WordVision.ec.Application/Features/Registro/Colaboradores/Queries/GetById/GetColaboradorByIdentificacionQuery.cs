using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.CacheRepositories.Maestro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById
{
    public class GetColaboradorByIdentificacionQuery : IRequest<Result<GetColaboradorByIdResponse>>
    {
        public string Identificacion { get; set; }

        public class GetColaboradorByIdentificacionQueryHandler : IRequestHandler<GetColaboradorByIdentificacionQuery, Result<GetColaboradorByIdResponse>>
        {
            private readonly IColaboradorCacheRepository _ColaboradorCache;
            private readonly IEstructuraCacheRepository _estructuraCache;
            private readonly IMapper _mapper;

            public GetColaboradorByIdentificacionQueryHandler(IEstructuraCacheRepository estructuraCache,IColaboradorCacheRepository colaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = colaboradorCache;
                _estructuraCache = estructuraCache;
                _mapper = mapper;
            }

           
            public async Task<Result<GetColaboradorByIdResponse>> Handle(GetColaboradorByIdentificacionQuery request, CancellationToken cancellationToken)
            {
                var Colaborador = await _ColaboradorCache.GetByIdentificacionAsync(request.Identificacion);
                var estructura = await _estructuraCache.GetByIdAsync(Colaborador.IdEstructura);
                var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(Colaborador);
                mappedColaborador.Nivel = estructura.Nivel;
                return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}
