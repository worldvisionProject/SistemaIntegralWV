using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById
{
    public class GetColaboradorByIdentificacionQuery : IRequest<Result<GetColaboradorByIdResponse>>
    {
        public string Identificacion { get; set; }

        public class GetColaboradorByIdentificacionQueryHandler : IRequestHandler<GetColaboradorByIdentificacionQuery, Result<GetColaboradorByIdResponse>>
        {
            private readonly IColaboradorCacheRepository _ColaboradorCache;
            private readonly IMapper _mapper;

            public GetColaboradorByIdentificacionQueryHandler(IColaboradorCacheRepository colaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = colaboradorCache;
                _mapper = mapper;
            }

           
            public async Task<Result<GetColaboradorByIdResponse>> Handle(GetColaboradorByIdentificacionQuery request, CancellationToken cancellationToken)
            {
                var Colaborador = await _ColaboradorCache.GetByIdentificacionAsync(request.Identificacion);
                var mappedColaborador = _mapper.Map<GetColaboradorByIdResponse>(Colaborador);
                return Result<GetColaboradorByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}
