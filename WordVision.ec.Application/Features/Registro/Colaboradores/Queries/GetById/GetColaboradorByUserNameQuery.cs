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
    public class GetColaboradorByUserNameQuery : IRequest<Result<GetColaboradorByIdResponse>>
    {
        public string UserName { get; set; }

        public class GetColaboradorByUserNameQueryHandler : IRequestHandler<GetColaboradorByUserNameQuery, Result<GetColaboradorByIdResponse>>
        {
            private readonly IColaboradorCacheRepository _ColaboradorCache;
            private readonly IEstructuraCacheRepository _estructuraCache;
            private readonly IMapper _mapper;

            public GetColaboradorByUserNameQueryHandler(IEstructuraCacheRepository estructuraCache,IColaboradorCacheRepository colaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = colaboradorCache;
                _estructuraCache = estructuraCache;
                _mapper = mapper;
            }

           
            public async Task<Result<GetColaboradorByIdResponse>> Handle(GetColaboradorByUserNameQuery request, CancellationToken cancellationToken)
            {
                int nivel = 0;
                var Colaborador = await _ColaboradorCache.GetByUserNameAsync(request.UserName);
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
