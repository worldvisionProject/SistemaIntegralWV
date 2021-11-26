using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById
{

    public class GetColaboradorByNivelQuery : IRequest<Result<List<GetColaboradorByIdResponse>>>
    {
        public int Nivel1 { get; set; }
        public int Nivel2 { get; set; }
        public class GetColaboradorByNivelQueryHandler : IRequestHandler<GetColaboradorByNivelQuery, Result<List<GetColaboradorByIdResponse>>>
        {
            private readonly IColaboradorCacheRepository _ColaboradorCache;
            private readonly IMapper _mapper;

            public GetColaboradorByNivelQueryHandler(IColaboradorCacheRepository colaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = colaboradorCache;
                _mapper = mapper;
            }


            public async Task<Result<List<GetColaboradorByIdResponse>>> Handle(GetColaboradorByNivelQuery request, CancellationToken cancellationToken)
            {
                var Colaborador = await _ColaboradorCache.GetByNivelAsync(request.Nivel1, request.Nivel2);
                var mappedColaborador = _mapper.Map<List<GetColaboradorByIdResponse>>(Colaborador);

                return Result<List<GetColaboradorByIdResponse>>.Success(mappedColaborador);

            }
        }
    }

}
