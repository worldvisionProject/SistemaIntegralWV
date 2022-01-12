using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Planificacion.Objetivoes.Queries.GetById
{
    public class GetObjetivoByIdQuery : IRequest<Result<GetObjetivoByIdResponse>>
    {


        public int Id { get; set; }

        public class GetObjetivoByIdQueryHandler : IRequestHandler<GetObjetivoByIdQuery, Result<GetObjetivoByIdResponse>>
        {
            private readonly IObjetivoRepository _ObjetivoRepository;
          
            private readonly IMapper _mapper;

            public GetObjetivoByIdQueryHandler( IObjetivoRepository ObjetivoRepository, IMapper mapper)
            {
                _ObjetivoRepository = ObjetivoRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetObjetivoByIdResponse>> Handle(GetObjetivoByIdQuery query, CancellationToken cancellationToken)
            {
                var Objetivo = await _ObjetivoRepository.GetByIdAsync(query.Id);
              
                var mappedObjetivo = _mapper.Map<GetObjetivoByIdResponse>(Objetivo);

                return Result<GetObjetivoByIdResponse>.Success(mappedObjetivo);
            }
        }
    }
}
