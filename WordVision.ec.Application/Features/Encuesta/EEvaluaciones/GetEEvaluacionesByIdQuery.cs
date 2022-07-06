using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EEvaluaciones
{
    public class GetEEvaluacionesByIdResponse : GenericResponse
    {
        public int Id { get; set; }
        public string eva_Nombre { get; set; }
        public DateTime eva_Desde { get; set; }
        public DateTime eva_Hasta { get; set; }


        public virtual List<EReporteTabulado> EReporteTabulados { get; set; }
        public virtual List<EMeta> EMetas { get; set; }
    }

    public class GetEEvaluacionesByIdQuery : GetEEvaluacionesByIdResponse, IRequest<Result<GetEEvaluacionesByIdResponse>>
    {
  
        public class GetEEvaluacionesByIdQueryHandler : IRequestHandler<GetEEvaluacionesByIdQuery, Result<GetEEvaluacionesByIdResponse>>
        {
            private readonly IEEvaluacionRepository _eEvaluacionesRepository;
            private readonly IMapper _mapper;

            public GetEEvaluacionesByIdQueryHandler(IEEvaluacionRepository eEvaluacionesRepository, IMapper mapper)
            {
                _eEvaluacionesRepository = eEvaluacionesRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEEvaluacionesByIdResponse>> Handle(GetEEvaluacionesByIdQuery query, CancellationToken cancellationToken)
            {
                var EEvaluacionModel = await _eEvaluacionesRepository.GetByIdAsync(query.Id);
                var mappedEEvaluaciones = _mapper.Map<GetEEvaluacionesByIdResponse>(EEvaluacionModel);

                return Result<GetEEvaluacionesByIdResponse>.Success(mappedEEvaluaciones);
            }
        }

    }




}
