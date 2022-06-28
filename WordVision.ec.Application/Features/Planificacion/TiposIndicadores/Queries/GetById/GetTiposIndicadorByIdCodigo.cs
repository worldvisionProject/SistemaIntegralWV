using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById
{
    public class GetTiposIndicadorByIdCodigo : IRequest<Result<GetTiposIndicadorByIdResponse>>
    {
        public int Id { get; set; }

        public class GetTiposIndicadorByIdCodigoHandler : IRequestHandler<GetTiposIndicadorByIdCodigo, Result<GetTiposIndicadorByIdResponse>>
        {
            private readonly ITiposIndicadorRepository _tiposIndicadorRepository;

            private readonly IMapper _mapper;

            public GetTiposIndicadorByIdCodigoHandler(ITiposIndicadorRepository tiposIndicadorRepository, IMapper mapper)
            {
                _tiposIndicadorRepository = tiposIndicadorRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetTiposIndicadorByIdResponse>> Handle(GetTiposIndicadorByIdCodigo query, CancellationToken cancellationToken)
            {
                var meta = await _tiposIndicadorRepository.GetByIdAsync(query.Id);
                var mappedMeta = _mapper.Map<GetTiposIndicadorByIdResponse>(meta);

                return Result<GetTiposIndicadorByIdResponse>.Success(mappedMeta);
            }
        }
    }
}
