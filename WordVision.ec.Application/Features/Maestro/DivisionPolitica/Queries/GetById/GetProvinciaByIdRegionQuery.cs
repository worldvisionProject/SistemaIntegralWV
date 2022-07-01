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
    public class GetProvinciaByIdRegionQuery : IRequest<Result<List<GetProvinciaByIdResponse>>>
    {
        public int IdRegion { get; set; }

        public class GetProvinciaByIdRegionQueryHandler : IRequestHandler<GetProvinciaByIdRegionQuery, Result<List<GetProvinciaByIdResponse>>>
        {
            private readonly IPaisRepository _paisCache;
            private readonly IMapper _mapper;

            public GetProvinciaByIdRegionQueryHandler(IPaisRepository paisCache, IMapper mapper)
            {
                _paisCache = paisCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetProvinciaByIdResponse>>> Handle(GetProvinciaByIdRegionQuery query, CancellationToken cancellationToken)
            {
                var Pais = await _paisCache.GetByIdRegionAsync(query.IdRegion);
                    var mappedPais = _mapper.Map<List<GetProvinciaByIdResponse>>(Pais);

                return Result<List<GetProvinciaByIdResponse>>.Success(mappedPais);
            }
        }
    }
}
