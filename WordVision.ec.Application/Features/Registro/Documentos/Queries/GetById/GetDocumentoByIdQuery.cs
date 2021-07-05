using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Documentos.Queries.GetById
{
    public class GetDocumentoByIdQuery : IRequest<Result<GetDocumentoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetDocumentoByIdQueryHandler : IRequestHandler<GetDocumentoByIdQuery, Result<GetDocumentoByIdResponse>>
        {
            private readonly IDocumentoCacheRepository _documentoCache;
            private readonly IMapper _mapper;

            public GetDocumentoByIdQueryHandler(IDocumentoCacheRepository documentoCache, IMapper mapper)
            {
                _documentoCache = documentoCache;
                _mapper = mapper;
            }

            public async Task<Result<GetDocumentoByIdResponse>> Handle(GetDocumentoByIdQuery query, CancellationToken cancellationToken)
            {
                var Colaborador = await _documentoCache.GetByIdAsync(query.Id);
                var mappedColaborador = _mapper.Map<GetDocumentoByIdResponse>(Colaborador);
                return Result<GetDocumentoByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}