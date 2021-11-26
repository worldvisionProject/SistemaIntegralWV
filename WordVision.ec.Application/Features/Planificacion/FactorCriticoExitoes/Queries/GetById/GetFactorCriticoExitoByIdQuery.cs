using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById
{
    public class GetFactorCriticoExitoByIdQuery : IRequest<Result<GetFactorCriticoExitoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetFactorCriticoExitoByIdQueryHandler : IRequestHandler<GetFactorCriticoExitoByIdQuery, Result<GetFactorCriticoExitoByIdResponse>>
        {
            private readonly IFactorCriticoExitoRepository _FactorCriticoExitoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetFactorCriticoExitoByIdQueryHandler(IFactorCriticoExitoRepository FactorCriticoExitoCache, IMapper mapper)
            {
                _FactorCriticoExitoCache = FactorCriticoExitoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetFactorCriticoExitoByIdResponse>> Handle(GetFactorCriticoExitoByIdQuery query, CancellationToken cancellationToken)
            {
                var FactorCriticoExito = await _FactorCriticoExitoCache.GetByIdAsync(query.Id);
                var mappedFactorCriticoExito = _mapper.Map<GetFactorCriticoExitoByIdResponse>(FactorCriticoExito);

                return Result<GetFactorCriticoExitoByIdResponse>.Success(mappedFactorCriticoExito);
            }
        }
    }
}