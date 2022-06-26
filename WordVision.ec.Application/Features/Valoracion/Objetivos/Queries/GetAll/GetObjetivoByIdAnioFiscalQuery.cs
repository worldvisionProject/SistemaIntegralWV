using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetAll
{
    public class GetObjetivoByIdAnioFiscalQuery : IRequest<Result<List<GetObjetivoByIdResponse>>>
    {


        public int IdAnioFiscal { get; set; }

        public class GetObjetivoByIdAnioFiscalQueryHandler : IRequestHandler<GetObjetivoByIdAnioFiscalQuery, Result<List<GetObjetivoByIdResponse>>>
        {
            private readonly IObjetivoRepository _ObjetivoRepository;
          
            private readonly IMapper _mapper;

            public GetObjetivoByIdAnioFiscalQueryHandler( IObjetivoRepository ObjetivoRepository, IMapper mapper)
            {
                _ObjetivoRepository = ObjetivoRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetObjetivoByIdResponse>>> Handle(GetObjetivoByIdAnioFiscalQuery query, CancellationToken cancellationToken)
            {
                var Objetivo = await _ObjetivoRepository.GetListxAnioFiscalAsync(query.IdAnioFiscal);
              
                var mappedObjetivo = _mapper.Map<List<GetObjetivoByIdResponse>>(Objetivo);

                return Result<List<GetObjetivoByIdResponse>>.Success(mappedObjetivo);
            }
        }
    }
}
