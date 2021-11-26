using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorPOAes.Queries.GetById
{
    public class GetIndicadorPOAByIdQuery : IRequest<Result<GetIndicadorPOAByIdResponse>>
    {
        public int Id { get; set; }

        public class GetIndicadorPOAByIdQueryHandler : IRequestHandler<GetIndicadorPOAByIdQuery, Result<GetIndicadorPOAByIdResponse>>
        {
            private readonly IIndicadorPOARepository _IndicadorPOACache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetIndicadorPOAByIdQueryHandler(IIndicadorPOARepository IndicadorPOACache, IMapper mapper)
            {
                _IndicadorPOACache = IndicadorPOACache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetIndicadorPOAByIdResponse>> Handle(GetIndicadorPOAByIdQuery query, CancellationToken cancellationToken)
            {
                var IndicadorPOA = await _IndicadorPOACache.GetByIdAsync(query.Id);
                var mappedIndicadorPOA = _mapper.Map<GetIndicadorPOAByIdResponse>(IndicadorPOA);

                return Result<GetIndicadorPOAByIdResponse>.Success(mappedIndicadorPOA);
            }
        }
    }
}