using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById
{
    public class GetPlanificacionResultadoByIdLiderQuery : IRequest<Result<List<PlanificacionResultadoResponse>>>
    {
         public int IdLider { get; set; }
       
        public class GetPlanificacionResultadoByIdLiderQueryHandler : IRequestHandler<GetPlanificacionResultadoByIdLiderQuery, Result<List<PlanificacionResultadoResponse>>>
        {
            private readonly IPlanificacionResultadoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetPlanificacionResultadoByIdLiderQueryHandler(IPlanificacionResultadoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<PlanificacionResultadoResponse>>> Handle(GetPlanificacionResultadoByIdLiderQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListxLiderAsync(query.IdLider);
                var mappedObj = _mapper.Map< List<PlanificacionResultadoResponse>>(obj);

                return Result<List<PlanificacionResultadoResponse>>.Success(mappedObj);
            }
        }

    }
}
