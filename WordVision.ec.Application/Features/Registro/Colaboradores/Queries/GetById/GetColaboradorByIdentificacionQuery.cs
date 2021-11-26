using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
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
        public string UserName { get; set; }
        public class GetColaboradorByIdentificacionQueryHandler : IRequestHandler<GetColaboradorByIdentificacionQuery, Result<GetColaboradorByIdResponse>>
        {
            private readonly IColaboradorCacheRepository _ColaboradorCache;
            private readonly IEstructuraCacheRepository _estructuraCache;
            private readonly IMapper _mapper;

            public GetColaboradorByIdentificacionQueryHandler(IEstructuraCacheRepository estructuraCache, IColaboradorCacheRepository colaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = colaboradorCache;
                _estructuraCache = estructuraCache;
                _mapper = mapper;
            }


            public async Task<Result<GetColaboradorByIdResponse>> Handle(GetColaboradorByIdentificacionQuery request, CancellationToken cancellationToken)
            {
                int nivel = 0;
                int reportaA = 0;
                var Colaborador = await _ColaboradorCache.GetByIdentificacionAsync(request.Identificacion);
                if (Colaborador != null)
                {
                    try
                    {
                        var estructura = await _ColaboradorCache.GetByEstructuraAsync(Colaborador.Estructuras.ReportaID);
                        if (estructura != null)
                        {
                            reportaA = estructura.Id;
                        }
                    }
                    catch
                    { }

                    var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(Colaborador);
                    mappedColaborador.CodReportaA = reportaA;
                    return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
                }
                else
                {
                    Colaborador = await _ColaboradorCache.GetByUserNameAsync(request.UserName);
                    if (Colaborador != null)
                    {

                        //var estructura = await _estructuraCache.GetByIdAsync(Colaborador.IdEstructura);
                        //if (estructura != null)
                        //    nivel = estructura.Nivel;


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
}
