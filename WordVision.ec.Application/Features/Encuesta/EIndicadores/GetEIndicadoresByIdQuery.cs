using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadores
{
    public class GetEIndicadoresByIdResponse
    {
        public string Id { get; set; }
        public string ind_LogFrame { get; set; }
        public string ind_Nombre { get; set; }
        public string ind_Resultado { get; set; }
        public string ind_Definicion { get; set; }
        public string ind_Fuente { get; set; }
        public string ind_Seccion { get; set; }
        public string ind_Preguntas { get; set; }
        public string ind_Medicion { get; set; }
        public string int_PlanTabulados { get; set; }
        public string ind_UnidadMedida { get; set; }
        public int ind_Frecuencia { get; set; }
        public string ind_tipo { get; set; }
        public string ind_proyecto { get; set; }


        public string EObjetivoId { get; set; }
        public virtual List<EProgramaIndicador> EProgramaIndicadores { get; set; }
        public virtual List<EReporteTabulado> EReporteTabulados { get; set; }
        public virtual List<EMeta> EMetas { get; set; }

    }

    public class GetEIndicadoresByIdQuery : IRequest<Result<GetEIndicadoresByIdResponse>>
    {
        public string Id { get; set; }

        public class GetEIndicadoresByIdQueryHandler : IRequestHandler<GetEIndicadoresByIdQuery, Result<GetEIndicadoresByIdResponse>>
        {
            private readonly IEIndicadorRepository _eIndicadoresRepository;
            private readonly IMapper _mapper;

            public GetEIndicadoresByIdQueryHandler(IEIndicadorRepository eIndicadoresRepository, IMapper mapper)
            {
                _eIndicadoresRepository = eIndicadoresRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEIndicadoresByIdResponse>> Handle(GetEIndicadoresByIdQuery query, CancellationToken cancellationToken)
            {
                var EIndicadorModel = await _eIndicadoresRepository.GetByIdAsync(query.Id);
                var mappedEIndicadores = _mapper.Map<GetEIndicadoresByIdResponse>(EIndicadorModel);

                return Result<GetEIndicadoresByIdResponse>.Success(mappedEIndicadores);
            }
        }

    }





}
