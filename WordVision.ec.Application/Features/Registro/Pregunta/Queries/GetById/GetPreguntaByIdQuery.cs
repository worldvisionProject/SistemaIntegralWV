using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById
{
    public class GetPreguntaByIdQuery : IRequest<Result<GetPreguntaByIdResponse>>
    {
        public int Id { get; set; }

        public class GetDocumentoByIdQueryHandler : IRequestHandler<GetPreguntaByIdQuery, Result<GetPreguntaByIdResponse>>
        {
            private readonly IPreguntaCacheRepository _preguntaCache;
            private readonly IMapper _mapper;

            public GetDocumentoByIdQueryHandler(IPreguntaCacheRepository preguntaCache, IMapper mapper)
            {
                _preguntaCache = preguntaCache;
                _mapper = mapper;
            }

            public async Task<Result<GetPreguntaByIdResponse>> Handle(GetPreguntaByIdQuery query, CancellationToken cancellationToken)
            {
                var documento = await _preguntaCache.GetByIdAsync(query.Id);
                var mappedDocumento = _mapper.Map<GetPreguntaByIdResponse>(documento);
                return Result<GetPreguntaByIdResponse>.Success(mappedDocumento);
            }
        }
    }
}