using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetById
{
    public class GetTiposIndicadorById : IRequest<Result<List<GetTiposIndicadorByIdResponse>>>
    {
        public int IdTipoIndicador { get; set; }

        public class GetTiposIndicadorByIdHandler : IRequestHandler<GetTiposIndicadorById, Result<List<GetTiposIndicadorByIdResponse>>>
        {
            private readonly ITiposIndicadorRepository _tiposIndicadorRepository;

            private readonly IMapper _mapper;

            public GetTiposIndicadorByIdHandler(ITiposIndicadorRepository tiposIndicadorRepository, IMapper mapper)
            {
                _tiposIndicadorRepository = tiposIndicadorRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetTiposIndicadorByIdResponse>>> Handle(GetTiposIndicadorById query, CancellationToken cancellationToken)
            {
                var meta = await _tiposIndicadorRepository.GetListxTipoAsync(query.IdTipoIndicador);
                var mappedMeta = _mapper.Map<List<GetTiposIndicadorByIdResponse>>(meta);

                return Result<List<GetTiposIndicadorByIdResponse>>.Success(mappedMeta);
            }
        }
    }
}
