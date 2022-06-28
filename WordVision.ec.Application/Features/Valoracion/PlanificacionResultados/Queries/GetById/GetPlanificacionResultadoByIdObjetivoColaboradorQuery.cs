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
    public class GetPlanificacionResultadoByIdObjetivoColaboradorQuery : IRequest<Result<List<GetPlanificacionResultadoByIdResponse>>>
    {
        public int IdObjetivo { get; set; }
        public int IdColaborador { get; set; }
        public class GetPlanificacionResultadoByIdObjetivoColaboradorQueryHandler : IRequestHandler<GetPlanificacionResultadoByIdObjetivoColaboradorQuery, Result<List<GetPlanificacionResultadoByIdResponse>>>
        {
            private readonly IPlanificacionResultadoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetPlanificacionResultadoByIdObjetivoColaboradorQueryHandler(IPlanificacionResultadoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetPlanificacionResultadoByIdResponse>>> Handle(GetPlanificacionResultadoByIdObjetivoColaboradorQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListObjetivoxColaboradorAsync(query.IdObjetivo,query.IdColaborador);
                var mappedObj = _mapper.Map< List<GetPlanificacionResultadoByIdResponse>>(obj);

                return Result<List<GetPlanificacionResultadoByIdResponse>>.Success(mappedObj);
            }
        }

    }
}
