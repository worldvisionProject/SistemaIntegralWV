using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EReporteConsolidados
{

    public class GetAllEReporteConsolidadosResponse
    {
        public string rpt_Proyecto { get; set; }
        public string rpt_Programa { get; set; }
        public string rpt_LogFrame { get; set; }
        public string rpt_Objetivo { get; set; }
        public string rpt_IndicadorCodigo { get; set; }
        public string rpt_IndicadorNombre { get; set; }
        public string rpt_UnidadMedida { get; set; }
        public string rpt_Frecuencia { get; set; }
        public decimal? rpt_LineaBaseResultado { get; set; }
        public decimal? rpt_Anio4_meta { get; set; }
        public decimal? rpt_Anio4_ejec { get; set; }
        public decimal? rpt_Anio5_meta { get; set; }
        public decimal? rpt_Anio5_ejec { get; set; }
        public decimal? rpt_Anio6_meta { get; set; }
        public decimal? rpt_Anio6_ejec { get; set; }
        public decimal? rpt_Total_meta { get; set; }
        public decimal? rpt_Total_ejec { get; set; }
        public int rpt_Region { get; set; }
        public string rpt_Provincia { get; set; }
        public string rpt_Canton { get; set; }
        public string rpt_Parroquia { get; set; }

    }


    public class GetAllEReporteConsolidadosQuery : IRequest<Result<List<GetAllEReporteConsolidadosResponse>>>
    {
        public int EvaluacionId { get; set; }
        public int RegionId { get; set; }
        public string ProvinciaId { get; set; }
        public string CantonId { get; set; }
        public string ProgramaId { get; set; }
        public string IndicadorId { get; set; }

        public GetAllEReporteConsolidadosQuery()
        {
        }
        public class GetAllEReporteConsolidadosQueryHandler : IRequestHandler<GetAllEReporteConsolidadosQuery, Result<List<GetAllEReporteConsolidadosResponse>>>
        {
            private readonly IEReporteConsolidadoRepository _eReporteConsolidado;
            private readonly IMapper _mapper;

            public GetAllEReporteConsolidadosQueryHandler(IEReporteConsolidadoRepository eReporteConsolidado, IMapper mapper)
            {
                _eReporteConsolidado = eReporteConsolidado;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEReporteConsolidadosResponse>>> Handle(GetAllEReporteConsolidadosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de datos
                var eReporteConsolidadosList = await _eReporteConsolidado.GetListAsync(request.EvaluacionId, request.RegionId, request.ProvinciaId, request.CantonId, request.ProgramaId, request.IndicadorId);

                //Mapeamos la estructura de la base (EReporteConsolidado) a la estructura deseada tipo GetAllEReporteConsolidadosResponse
                List<GetAllEReporteConsolidadosResponse> mappedEReporteConsolidados = _mapper.Map<List<GetAllEReporteConsolidadosResponse>>(eReporteConsolidadosList);

                return Result<List<GetAllEReporteConsolidadosResponse>>.Success(mappedEReporteConsolidados);
            }
        }


    }

}
