using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.ETabulados
{
    public class GetAllETabuladosResponse
    {
        public string CodigoIndicador { get; set; }
        public string CodigoPA { get; set; }
        public string PA { get; set; }
        public string Indicador { get; set; }
        public string TipoIndicador { get; set; }
        public int NumeroTotal { get; set; }
        public int EntrevistadosTotal { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal Result { get; set; }
        public int CodigoRegion { get; set; }
        public string CodigoProvincia { get; set; }
        public string CodigoCanton { get; set; }
    }


    public class GetAllETabuladosQuery : IRequest<Result<List<GetAllETabuladosResponse>>>
    {
        public int EvaluacionId { get; set; }
        public int RegionId { get; set; }
        public string ProvinciaId { get; set; }
        public string CantonId { get; set; }
        public string ParroquiaId { get; set; }
        public string ComunidadId { get; set; }
        public string ProgramaId { get; set; }
        public string IndicadorId { get; set; }

        public GetAllETabuladosQuery()
        {
        }
        public class GetAllETabuladosQueryHandler : IRequestHandler<GetAllETabuladosQuery, Result<List<GetAllETabuladosResponse>>>
        {
            private readonly IETabuladoRepository _eTabulado;
            private readonly IMapper _mapper;

            public GetAllETabuladosQueryHandler(IETabuladoRepository eTabulado, IMapper mapper)
            {
                _eTabulado = eTabulado;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllETabuladosResponse>>> Handle(GetAllETabuladosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var eTabuladosList = await _eTabulado.GetListAsync(request.EvaluacionId, request.RegionId, request.ProvinciaId, request.CantonId, request.ParroquiaId, request.ComunidadId, request.ProgramaId, request.IndicadorId);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEncuestaKobosResponse
                List<GetAllETabuladosResponse> mappedETabulados = _mapper.Map<List<GetAllETabuladosResponse>>(eTabuladosList);

                return Result<List<GetAllETabuladosResponse>>.Success(mappedETabulados);
            }
        }


    }
}
