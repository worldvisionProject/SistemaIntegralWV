using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Objetivos.Queries.GetById
{
    public class GetObjetivoByIdAnioQuery : IRequest<Result<GetObjetivoPonderacionResponse>>
    {


        public int Id { get; set; }

        public class GetObjetivoByIdAnioQueryHandler : IRequestHandler<GetObjetivoByIdAnioQuery, Result<GetObjetivoPonderacionResponse>>
        {
            private readonly IObjetivoRepository _ObjetivoRepository;
          
            private readonly IMapper _mapper;

            public GetObjetivoByIdAnioQueryHandler( IObjetivoRepository ObjetivoRepository, IMapper mapper)
            {
                _ObjetivoRepository = ObjetivoRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetObjetivoPonderacionResponse>> Handle(GetObjetivoByIdAnioQuery query, CancellationToken cancellationToken)
            {
                var Objetivo = await _ObjetivoRepository.GetPonderacionByIdAsync(query.Id);
              
                var mappedObjetivo = _mapper.Map<GetObjetivoPonderacionResponse>(Objetivo);

                return Result<GetObjetivoPonderacionResponse>.Success(mappedObjetivo);
            }
        }
    }
}
