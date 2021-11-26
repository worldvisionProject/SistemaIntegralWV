
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Pregunta.Queries.GetById
{
    public class GetPreguntasByIdDocumentoQuery : IRequest<Result<List<GetPreguntasByIdDocumentoResponse>>>
    {
        public int Id { get; set; }
        public GetPreguntasByIdDocumentoQuery()
        {
        }
    }

    public class GetPreguntasByIdDocumentoQueryHandler : IRequestHandler<GetPreguntasByIdDocumentoQuery, Result<List<GetPreguntasByIdDocumentoResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IPreguntaRepository _preguntaCache;
        public GetPreguntasByIdDocumentoQueryHandler(IPreguntaRepository preguntaCache, IMapper mapper)
        {
            _preguntaCache = preguntaCache;
            _mapper = mapper;
        }


        public async Task<Result<List<GetPreguntasByIdDocumentoResponse>>> Handle(GetPreguntasByIdDocumentoQuery request, CancellationToken cancellationToken)
        {
            var documento = await _preguntaCache.GetByIdDocumentoAsync(request.Id);
            var mappedDocumento = _mapper.Map<List<GetPreguntasByIdDocumentoResponse>>(documento);
            return Result<List<GetPreguntasByIdDocumentoResponse>>.Success(mappedDocumento);
        }
    }

}
