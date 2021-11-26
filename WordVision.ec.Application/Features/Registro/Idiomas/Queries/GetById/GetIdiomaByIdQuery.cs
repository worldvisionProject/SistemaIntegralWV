using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Idiomas.Queries.GetById
{
    public class GetIdiomaByIdQuery : IRequest<Result<GetByIdResponse>>
    {
        public int Id { get; set; }

        public class GetIdiomaByIdQueryHandler : IRequestHandler<GetIdiomaByIdQuery, Result<GetByIdResponse>>
        {
            private readonly IIdiomaRepository _idiomaCache;
            private readonly IMapper _mapper;

            public GetIdiomaByIdQueryHandler(IIdiomaRepository idiomaCache, IMapper mapper)
            {
                _idiomaCache = idiomaCache;
                _mapper = mapper;
            }

            public async Task<Result<GetByIdResponse>> Handle(GetIdiomaByIdQuery query, CancellationToken cancellationToken)
            {
                var idioma = await _idiomaCache.GetByIdAsync(query.Id);
                var mappedIdioma = _mapper.Map<GetByIdResponse>(idioma);
                return Result<GetByIdResponse>.Success(mappedIdioma);
            }
        }
    }
}
