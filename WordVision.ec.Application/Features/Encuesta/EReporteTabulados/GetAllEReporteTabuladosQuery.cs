using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EReporteTabulados
{

    public class GetAllEReporteTabuladosResponse
    {
        public string CodigoIndicador { get; set; }
        public string CodigoPA { get; set; }
        public string PA { get; set; }
        public string Indicador { get; set; }
        public string TipoIndicador { get; set; }
        public decimal NumeroTotal { get; set; }
        public decimal EntrevistadosTotal { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal Result { get; set; }
        public int CodigoRegion { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoCanton { get; set; }

    }


    public class GetAllEReporteTabuladosQuery : IRequest<Result<List<GetAllEReporteTabuladosResponse>>>
    {
        public int EvaluacionId { get; set; }
        public int RegionId { get; set; }
        public string ProvinciaId { get; set; }
        public string CantonId { get; set; }
        public string ProgramaId { get; set; }
        public string IndicadorId { get; set; }

        public GetAllEReporteTabuladosQuery()
        {
        }
        public class GetAllEReporteTabuladosQueryHandler : IRequestHandler<GetAllEReporteTabuladosQuery, Result<List<GetAllEReporteTabuladosResponse>>>
        {
            private readonly IEReporteTabuladoRepository _eReporteTabulado;
            private readonly IMapper _mapper;

            public GetAllEReporteTabuladosQueryHandler(IEReporteTabuladoRepository eReporteTabulado, IMapper mapper)
            {
                _eReporteTabulado = eReporteTabulado;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEReporteTabuladosResponse>>> Handle(GetAllEReporteTabuladosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de datos
                var eReporteTabuladosList = await _eReporteTabulado.GetListAsync(request.EvaluacionId, request.RegionId, request.ProvinciaId, request.CantonId, request.ProgramaId, request.IndicadorId);

                //Mapeamos la estructura de la base (EReporteTabulado) a la estructura deseada tipo GetAllEReporteTabuladosResponse
                List<GetAllEReporteTabuladosResponse> mappedEReporteTabulados = _mapper.Map<List<GetAllEReporteTabuladosResponse>>(eReporteTabuladosList);

                return Result<List<GetAllEReporteTabuladosResponse>>.Success(mappedEReporteTabulados);
            }
        }


    }

}
