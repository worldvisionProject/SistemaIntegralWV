using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById
{
    public class GetObjetivoEstrategicoByIdQuery : IRequest<Result<GetObjetivoEstrategicoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetObjetivoEstrategicoByIdQueryHandler : IRequestHandler<GetObjetivoEstrategicoByIdQuery, Result<GetObjetivoEstrategicoByIdResponse>>
        {
            private readonly IObjetivoEstrategicoRepository _ObjetivoEstrategicoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;
         
            private readonly IMapper _mapper;

            public GetObjetivoEstrategicoByIdQueryHandler( IObjetivoEstrategicoRepository ObjetivoEstrategicoCache, IMapper mapper)
            {
                _ObjetivoEstrategicoCache = ObjetivoEstrategicoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetObjetivoEstrategicoByIdResponse>> Handle(GetObjetivoEstrategicoByIdQuery query, CancellationToken cancellationToken)
            {
                var ObjetivoEstrategico = await _ObjetivoEstrategicoCache.GetByIdAsync(query.Id);
                var mappedObjetivoEstrategico = _mapper.Map<GetObjetivoEstrategicoByIdResponse>(ObjetivoEstrategico);
                
                return Result<GetObjetivoEstrategicoByIdResponse>.Success(mappedObjetivoEstrategico);
            }
        }
    }
}