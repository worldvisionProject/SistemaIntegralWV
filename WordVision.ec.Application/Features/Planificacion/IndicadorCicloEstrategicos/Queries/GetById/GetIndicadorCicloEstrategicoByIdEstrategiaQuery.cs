using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById
{


    public class GetIndicadorCicloEstrategicoByIdEstrategiaQuery : IRequest<Result<List<GetIndicadorCicloEstrategicoByIdResponse>>>
    {
        public int Id { get; set; }

        public class GetIndicadorCicloEstrategicoByIdEstrategiaQueryHandler : IRequestHandler<GetIndicadorCicloEstrategicoByIdEstrategiaQuery, Result<List<GetIndicadorCicloEstrategicoByIdResponse>>>
        {
            private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetIndicadorCicloEstrategicoByIdEstrategiaQueryHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetIndicadorCicloEstrategicoByIdResponse>>> Handle(GetIndicadorCicloEstrategicoByIdEstrategiaQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListxEstrategiaAsync(query.Id);
                var mappedObj = _mapper.Map<List<GetIndicadorCicloEstrategicoByIdResponse>>(obj);

                return Result<List<GetIndicadorCicloEstrategicoByIdResponse>>.Success(mappedObj);
            }
        }
    }
}
