using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById
{
    public class GetPlanificacionResultadoByIdObjetivoQuery : IRequest<Result<List<GetPlanificacionResultadoByIdResponse>>>
    {
        public int IdObjetivo { get; set; }

        public class GetPlanificacionResultadoByIdObjetivoQueryHandler : IRequestHandler<GetPlanificacionResultadoByIdObjetivoQuery, Result<List<GetPlanificacionResultadoByIdResponse>>>
        {
            private readonly IPlanificacionResultadoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetPlanificacionResultadoByIdObjetivoQueryHandler(IPlanificacionResultadoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetPlanificacionResultadoByIdResponse>>> Handle(GetPlanificacionResultadoByIdObjetivoQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListxObjetivoAsync(query.IdObjetivo);
                var mappedObj = _mapper.Map< List<GetPlanificacionResultadoByIdResponse>>(obj);

                return Result<List<GetPlanificacionResultadoByIdResponse>>.Success(mappedObj);
            }
        }

    }
}
