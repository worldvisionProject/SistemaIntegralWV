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

namespace WordVision.ec.Application.Features.Encuesta.EProyectos
{
    public class GetAllEProyectosResponse : GenericResponse
    {
        public int Id { get; set; }
        public string py_nombre { get; set; }
    }
    public class GetAllEProyectosQuery : GetAllEProyectosResponse, IRequest<Result<List<GetAllEProyectosResponse>>>
    {
        public GetAllEProyectosQuery()
        {
        }
        public class GetAllEProyectosQueryHandler : IRequestHandler<GetAllEProyectosQuery, Result<List<GetAllEProyectosResponse>>>
        {
            private readonly IEProyectoRepository _eProyecto;
            private readonly IMapper _mapper;

            public GetAllEProyectosQueryHandler(IEProyectoRepository eProyecto,
                                                    IMapper mapper)
            {
                _eProyecto = eProyecto;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEProyectosResponse>>> Handle(GetAllEProyectosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EProyectoList = await _eProyecto.GetListAsync(request.Include);

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEProyectosResponse
                var mappedEProyectos = _mapper.Map<List<GetAllEProyectosResponse>>(EProyectoList);


                return Result<List<GetAllEProyectosResponse>>.Success(mappedEProyectos);
            }
        }




    }
}
