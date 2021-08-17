using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById
{
    public class GetIndicadorEstrategicoByIdQuery : IRequest<Result<GetIndicadorEstrategicoByIdResponse>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public string IdCreadoPor { get; set; }
        public class GetIndicadorEstrategicoByIdQueryHandler : IRequestHandler<GetIndicadorEstrategicoByIdQuery, Result<GetIndicadorEstrategicoByIdResponse>>
        {
            private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;
         
            private readonly IMapper _mapper;

            public GetIndicadorEstrategicoByIdQueryHandler( IIndicadorEstrategicoRepository IndicadorEstrategicoCache, IMapper mapper)
            {
                _IndicadorEstrategicoCache = IndicadorEstrategicoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetIndicadorEstrategicoByIdResponse>> Handle(GetIndicadorEstrategicoByIdQuery query, CancellationToken cancellationToken)
            {
              
                var IndicadorEstrategico = await _IndicadorEstrategicoCache.GetByIdAsync(query.Id,query.IdColaborador, query.IdCreadoPor);
                var mappedIndicadorEstrategico = _mapper.Map<GetIndicadorEstrategicoByIdResponse>(IndicadorEstrategico);
                
                return Result<GetIndicadorEstrategicoByIdResponse>.Success(mappedIndicadorEstrategico);
            }
        }
    }
}