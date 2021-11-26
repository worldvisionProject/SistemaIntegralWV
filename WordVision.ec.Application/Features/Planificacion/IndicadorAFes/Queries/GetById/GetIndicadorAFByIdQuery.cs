using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorAFes.Queries.GetById
{
    public class GetIndicadorAFByIdQuery : IRequest<Result<GetIndicadorAFByIdResponse>>
    {
        public int Id { get; set; }

        public class GetIndicadorAFByIdQueryHandler : IRequestHandler<GetIndicadorAFByIdQuery, Result<GetIndicadorAFByIdResponse>>
        {
            private readonly IIndicadorAFRepository _IndicadorAFCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetIndicadorAFByIdQueryHandler(IIndicadorAFRepository IndicadorAFCache, IMapper mapper)
            {
                _IndicadorAFCache = IndicadorAFCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetIndicadorAFByIdResponse>> Handle(GetIndicadorAFByIdQuery query, CancellationToken cancellationToken)
            {
                var IndicadorAF = await _IndicadorAFCache.GetByIdAsync(query.Id);
                var mappedIndicadorAF = _mapper.Map<GetIndicadorAFByIdResponse>(IndicadorAF);

                return Result<GetIndicadorAFByIdResponse>.Success(mappedIndicadorAF);
            }
        }
    }
}