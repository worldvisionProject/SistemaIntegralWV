using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Terceros.Queries.GetById
{
    public class GetTerceroByIdFormularioQuery : IRequest<Result<GetByIdResponse>>
    {
        public int Id { get; set; }

        public class GetTerceroByIdQueryHandler : IRequestHandler<GetTerceroByIdFormularioQuery, Result<GetByIdResponse>>
        {
            private readonly ITerceroRepository _TerceroCache;
            private readonly IMapper _mapper;

            public GetTerceroByIdQueryHandler(ITerceroRepository TerceroCache, IMapper mapper)
            {
                _TerceroCache = TerceroCache;
                _mapper = mapper;
            }

            public async Task<Result<GetByIdResponse>> Handle(GetTerceroByIdFormularioQuery query, CancellationToken cancellationToken)
            {
                var tercero = await _TerceroCache.GetByIdAsync(query.Id);
                var mappedTercero = _mapper.Map<GetByIdResponse>(tercero);
                return Result<GetByIdResponse>.Success(mappedTercero);
            }
        }
    }
}
