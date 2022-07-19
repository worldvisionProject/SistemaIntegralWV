using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EReporteDAPs
{
    public class GetAllEReporteDAPsResponse
    {
        public string rpt_Proyecto { get; set; }
        public string rpt_Programa { get; set; }
        public string rpt_LogFrame { get; set; }
        public string rpt_Objetivo { get; set; }
        public string rpt_IndicadorCodigo { get; set; }
        public string rpt_IndicadorNombre { get; set; }
        public string rpt_IndicadorTipo { get; set; }
        public decimal? rpt_Apoyo { get; set; }
        public decimal? rpt_Empoderamiento { get; set; }
        public decimal? rpt_Limite { get; set; }
        public decimal? rpt_UsoConstructivo { get; set; }
        public decimal? rpt_Compromiso { get; set; }
        public decimal? rpt_Valores { get; set; }
        public decimal? rpt_Competencia { get; set; }
        public decimal? rpt_Identidad { get; set; }


        public decimal rpt_numerador { get; set; }
        public decimal rpt_denominador { get; set; }
        public decimal rpt_porcentaje { get; set; }
        public decimal rpt_resultado { get; set; }



        public int rpt_Region { get; set; }
        public string rpt_Provincia { get; set; }
        public string rpt_Canton { get; set; }

    }


    public class GetAllEReporteDAPsQuery : IRequest<Result<List<GetAllEReporteDAPsResponse>>>
    {
        public int EvaluacionId { get; set; }
        public int RegionId { get; set; }
        public string ProvinciaId { get; set; }
        public string CantonId { get; set; }
        public string ProgramaId { get; set; }
        public string IndicadorId { get; set; }

        public GetAllEReporteDAPsQuery()
        {
        }
        public class GetAllEReporteDAPsQueryHandler : IRequestHandler<GetAllEReporteDAPsQuery, Result<List<GetAllEReporteDAPsResponse>>>
        {
            private readonly IEReporteDAPRepository _eReporteDAP;
            private readonly IMapper _mapper;

            public GetAllEReporteDAPsQueryHandler(IEReporteDAPRepository eReporteDAP, IMapper mapper)
            {
                _eReporteDAP = eReporteDAP;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEReporteDAPsResponse>>> Handle(GetAllEReporteDAPsQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de datos
                var eReporteDAPsList = await _eReporteDAP.GetListAsync(request.EvaluacionId, request.RegionId, request.ProvinciaId, request.CantonId, request.ProgramaId, request.IndicadorId);

                //Mapeamos la estructura de la base (EReporteDAP) a la estructura deseada tipo GetAllEReporteDAPsResponse
                List<GetAllEReporteDAPsResponse> mappedEReporteDAPs = _mapper.Map<List<GetAllEReporteDAPsResponse>>(eReporteDAPsList);

                return Result<List<GetAllEReporteDAPsResponse>>.Success(mappedEReporteDAPs);
            }
        }


    }

}
