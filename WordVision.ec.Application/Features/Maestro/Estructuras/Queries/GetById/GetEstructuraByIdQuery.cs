using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.Estructuras.Queries.GetById
{
    public class GetEstructuraByIdQuery : IRequest<Result<GetEstructuraByIdResponse>>
    {
        public int Id { get; set; }

        public class GetEstructuraByIdQueryHandler : IRequestHandler<GetEstructuraByIdQuery, Result<GetEstructuraByIdResponse>>
        {
            private readonly IEstructuraRepository _EstructuraCache;
            private readonly IMapper _mapper;

            public GetEstructuraByIdQueryHandler(IEstructuraRepository EstructuraCache, IMapper mapper)
            {
                _EstructuraCache = EstructuraCache;
                _mapper = mapper;
            }

            public async Task<Result<GetEstructuraByIdResponse>> Handle(GetEstructuraByIdQuery query, CancellationToken cancellationToken)
            {
                var estructura = await _EstructuraCache.GetByIdAsync(query.Id);
                var mappedEstructura = _mapper.Map<GetEstructuraByIdResponse>(estructura);

                return Result<GetEstructuraByIdResponse>.Success(mappedEstructura);
            }
        }
    }
}