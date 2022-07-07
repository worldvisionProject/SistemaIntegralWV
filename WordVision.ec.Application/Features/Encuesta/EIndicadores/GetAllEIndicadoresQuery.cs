using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadores
{
    public class GetAllEIndicadoresResponse : GenericResponse
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
        public string ind_Operacion { get; set; }


        public string NombreCompleto { get; set; }
        public string EObjetivoId { get; set; }
        public virtual List<EMeta> EMetas { get; set; }
    }
    public class GetAllEIndicadoresQuery : GetAllEIndicadoresResponse, IRequest<Result<List<GetAllEIndicadoresResponse>>>
    {
        public GetAllEIndicadoresQuery()
        {
        }
        public class GetAllEIndicadoresQueryHandler : IRequestHandler<GetAllEIndicadoresQuery, Result<List<GetAllEIndicadoresResponse>>>
        {
            private readonly IEIndicadorRepository _eIndicador;
            private readonly IMapper _mapper;

            public GetAllEIndicadoresQueryHandler(IEIndicadorRepository eIndicador,
                                                    IMapper mapper)
            {
                _eIndicador = eIndicador;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEIndicadoresResponse>>> Handle(GetAllEIndicadoresQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EIndicadorList = await _eIndicador.GetListAsync(request.Include);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEIndicadoresResponse
                var mappedEIndicadores = _mapper.Map<List<GetAllEIndicadoresResponse>>(EIndicadorList);

                //Cambiamos el Nombre Completo
                foreach (GetAllEIndicadoresResponse fila in mappedEIndicadores)
                {
                    fila.NombreCompleto = "(" + fila.Id + ") " + fila.ind_Nombre;
                }


                return Result<List<GetAllEIndicadoresResponse>>.Success(mappedEIndicadores);
            }
        }




    }

}
