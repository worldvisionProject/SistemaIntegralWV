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

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetAllCached
{
    public class GetAllPlanificacionResultadosCachedQuery : IRequest<Result<List<ObjetivoResponse>>>
    {
        public int  IdAnioFiscal { get; set; }
        public int IdColaborador { get; set; }
        public GetAllPlanificacionResultadosCachedQuery()
        {
        }
    }

    public class GetAllPlanificacionResultadosCachedQueryHandler : IRequestHandler<GetAllPlanificacionResultadosCachedQuery, Result<List<ObjetivoResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IPlanificacionResultadoRepository _planificacionRepository;


        public  GetAllPlanificacionResultadosCachedQueryHandler(IPlanificacionResultadoRepository planificacionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _planificacionRepository = planificacionRepository;
        }



        public async Task<Result<List<ObjetivoResponse>>> Handle(GetAllPlanificacionResultadosCachedQuery request, CancellationToken cancellationToken)
        {
            var objetivoList = await _planificacionRepository.GetListxObjetivoxColaboradorAsync(request.IdAnioFiscal, request.IdColaborador);
            var mappedColaboradores = _mapper.Map<List<ObjetivoResponse>>(objetivoList);

            return Result<List<ObjetivoResponse>>.Success(mappedColaboradores);
        }
    }
}
