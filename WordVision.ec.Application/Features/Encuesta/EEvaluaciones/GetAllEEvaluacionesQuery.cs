using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EEvaluaciones
{

    public class GetAllEEvaluacionesResponse
    {
        public int Id { get; set; }
        public string eva_Nombre { get; set; }
        public DateTime eva_Desde { get; set; }
        public DateTime eva_Hasta { get; set; }
        public string NombreCompleto { get; set; }
    }
    public class GetAllEEvaluacionesQuery : IRequest<Result<List<GetAllEEvaluacionesResponse>>>
    {
        public GetAllEEvaluacionesQuery()
        {
        }
        public class GetAllEEvaluacionesQueryHandler : IRequestHandler<GetAllEEvaluacionesQuery, Result<List<GetAllEEvaluacionesResponse>>>
        {
            private readonly IEEvaluacionRepository _eEvaluacion;
            private readonly IMapper _mapper;

            public GetAllEEvaluacionesQueryHandler(IEEvaluacionRepository eEvaluacion,
                                                    IMapper mapper)
            {
                _eEvaluacion = eEvaluacion;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEEvaluacionesResponse>>> Handle(GetAllEEvaluacionesQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EEvaluacionList = await _eEvaluacion.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEEvaluacionesResponse
                var mappedEEValuaciones = _mapper.Map<List<GetAllEEvaluacionesResponse>>(EEvaluacionList);

                //Cambiamos el Nombre Completo
                foreach (GetAllEEvaluacionesResponse fila in mappedEEValuaciones)
                {
                    fila.NombreCompleto = fila.eva_Nombre + " Desde: " + fila.eva_Desde.ToShortDateString() + " Hasta: " + fila.eva_Hasta.ToShortDateString();  
                }


                return Result<List<GetAllEEvaluacionesResponse>>.Success(mappedEEValuaciones);
            }
        }




    }
}
