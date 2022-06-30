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
    public class GetCiudadByIdProvinciaQuery : IRequest<Result<List<GetCiudadByIdResponse>>>
    {
        public int IdProvincia { get; set; }

        public class GetCiudadByIdProvinciaQueryHandler : IRequestHandler<GetCiudadByIdProvinciaQuery, Result<List<GetCiudadByIdResponse>>>
        {
            private readonly IPaisRepository _paisCache;
            private readonly IMapper _mapper;

            public GetCiudadByIdProvinciaQueryHandler(IPaisRepository paisCache, IMapper mapper)
            {
                _paisCache = paisCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetCiudadByIdResponse>>> Handle(GetCiudadByIdProvinciaQuery query, CancellationToken cancellationToken)
            {
                var Pais = await _paisCache.GetByIdProvinciaAsync(query.IdProvincia);
                var mappedPais = _mapper.Map<List<GetCiudadByIdResponse>>(Pais);

                return Result<List<GetCiudadByIdResponse>>.Success(mappedPais);
            }
        }
    }
}
