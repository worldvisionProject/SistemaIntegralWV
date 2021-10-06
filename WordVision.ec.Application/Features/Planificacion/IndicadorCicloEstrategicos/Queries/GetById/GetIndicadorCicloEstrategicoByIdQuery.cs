using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorCicloEstrategicos.Queries.GetById
{
  

    public class GetIndicadorCicloEstrategicoByIdQuery : IRequest<Result<GetIndicadorCicloEstrategicoByIdResponse>>
    {
        public int Id { get; set; }
      
        public class GetIndicadorCicloEstrategicoByIdQueryHandler : IRequestHandler<GetIndicadorCicloEstrategicoByIdQuery, Result<GetIndicadorCicloEstrategicoByIdResponse>>
        {
            private readonly IIndicadorCicloEstrategicoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetIndicadorCicloEstrategicoByIdQueryHandler(IIndicadorCicloEstrategicoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetIndicadorCicloEstrategicoByIdResponse>> Handle(GetIndicadorCicloEstrategicoByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetIndicadorCicloEstrategicoByIdResponse>(obj);

                return Result<GetIndicadorCicloEstrategicoByIdResponse>.Success(mappedObj);
            }
        }
    }
}
