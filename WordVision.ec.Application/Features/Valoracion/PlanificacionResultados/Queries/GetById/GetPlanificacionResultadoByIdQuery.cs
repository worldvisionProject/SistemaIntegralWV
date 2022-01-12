using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById
{


    public class GetPlanificacionResultadoByIdQuery : IRequest<Result<GetPlanificacionResultadoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetPlanificacionResultadoByIdQueryHandler : IRequestHandler<GetPlanificacionResultadoByIdQuery, Result<GetPlanificacionResultadoByIdResponse>>
        {
            private readonly IPlanificacionResultadoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetPlanificacionResultadoByIdQueryHandler(IPlanificacionResultadoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetPlanificacionResultadoByIdResponse>> Handle(GetPlanificacionResultadoByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetPlanificacionResultadoByIdResponse>(obj);

                return Result<GetPlanificacionResultadoByIdResponse>.Success(mappedObj);
            }
        }
    }
}
