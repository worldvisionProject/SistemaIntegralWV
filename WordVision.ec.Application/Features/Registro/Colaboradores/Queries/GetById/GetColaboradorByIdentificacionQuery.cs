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
using WordVision.ec.Domain.Entities.Registro;

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
                int nivel = 0;
                var Colaborador = await _ColaboradorCache.GetByIdentificacionAsync(request.Identificacion);
                if (Colaborador != null)
                { 
                    try
                    {
                        var estructura = await _estructuraCache.GetByIdAsync(Colaborador.IdEstructura);
                        if (estructura != null)
                            nivel = estructura.Nivel;
                    }
                    catch
                    { }

                    var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(Colaborador);
                    mappedColaborador.Nivel = nivel;
                    return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
                }
                else
                {
                    var _colaborador = new Colaborador();
                    var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(_colaborador);
                    mappedColaborador.Nivel = nivel;
                    return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
                }

            }
        }
    }
}
