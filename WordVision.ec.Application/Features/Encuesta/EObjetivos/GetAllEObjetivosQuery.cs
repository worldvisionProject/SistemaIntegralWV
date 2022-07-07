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

namespace WordVision.ec.Application.Features.Encuesta.EObjetivos
{
    public class GetAllEObjetivosResponse : GenericResponse
    {
        public string Id { get; set; }
        public string obj_Nombre { get; set; }

        public string obj_Nivel { get; set; }
        public string obj_Outcome { get; set; }
        public string obj_Output { get; set; }
        public string obj_Activity { get; set; }

        public string NombreCompleto { get; set; }
        public int EProyectoId { get; set; }
        public EProyecto EProyecto { get; set; }

        

        public virtual List<EIndicador> EIndicadores { get; set; }

    }
    public class GetAllEObjetivosQuery : GetAllEObjetivosResponse, IRequest<Result<List<GetAllEObjetivosResponse>>>
    {
        public GetAllEObjetivosQuery()
        {
        }
        public class GetAllEObjetivosQueryHandler : IRequestHandler<GetAllEObjetivosQuery, Result<List<GetAllEObjetivosResponse>>>
        {
            private readonly IEObjetivoRepository _eObjetivo;
            private readonly IEProyectoRepository _eProyecto;
            private readonly IMapper _mapper;

            public GetAllEObjetivosQueryHandler(
                                                    IEObjetivoRepository eObjetivo,
                                                    IEProyectoRepository eProyecto,
                                                    IMapper mapper)
            {
                _eObjetivo = eObjetivo;
                _eProyecto = eProyecto;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEObjetivosResponse>>> Handle(GetAllEObjetivosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EObjetivoList = await _eObjetivo.GetListAsync(true);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEObjetivosResponse
                var mappedEObjetivos = _mapper.Map<List<GetAllEObjetivosResponse>>(EObjetivoList);

                //Cambiamos el Nombre Completo
                foreach (GetAllEObjetivosResponse fila in mappedEObjetivos)
                {
                    fila.NombreCompleto = fila.EProyecto.py_nombre + " (" + fila.Id + ") " + fila.obj_Nombre;
                }


                return Result<List<GetAllEObjetivosResponse>>.Success(mappedEObjetivos);
            }
        }




    }

}
