using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.DivisionPolitica.Queries.GetById
{
    public class GetPaisByIdQuery : IRequest<Result<GetPaisByIdResponse>>
    {
        public int Id { get; set; }

        public class GetPaisByIdQueryHandler : IRequestHandler<GetPaisByIdQuery, Result<GetPaisByIdResponse>>
        {
            private readonly IPaisRepository _paisCache;
            private readonly IMapper _mapper;

            public GetPaisByIdQueryHandler(IPaisRepository paisCache, IMapper mapper)
            {
                _paisCache = paisCache;
                _mapper = mapper;
            }

            public async Task<Result<GetPaisByIdResponse>> Handle(GetPaisByIdQuery query, CancellationToken cancellationToken)
            {
                var Pais = await _paisCache.GetByIdAsync(query.Id);
                var mappedPais = _mapper.Map<GetPaisByIdResponse>(Pais);

                return Result<GetPaisByIdResponse>.Success(mappedPais);
            }
        }
    }
}
