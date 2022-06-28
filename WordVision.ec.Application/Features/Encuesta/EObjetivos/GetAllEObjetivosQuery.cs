using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EObjetivos
{
    public class GetAllEObjetivosResponse
    {
        public string Id { get; set; }
        public string obj_Nombre { get; set; }

        public virtual List<EIndicador> EIndicadores { get; set; }

    }
    public class GetAllEObjetivosQuery : IRequest<Result<List<GetAllEObjetivosResponse>>>
    {
        public GetAllEObjetivosQuery()
        {
        }
        public class GetAllEObjetivosQueryHandler : IRequestHandler<GetAllEObjetivosQuery, Result<List<GetAllEObjetivosResponse>>>
        {
            private readonly IEObjetivoRepository _eObjetivo;
            private readonly IMapper _mapper;

            public GetAllEObjetivosQueryHandler(IEObjetivoRepository eObjetivo,
                                                    IMapper mapper)
            {
                _eObjetivo = eObjetivo;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEObjetivosResponse>>> Handle(GetAllEObjetivosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EObjetivoList = await _eObjetivo.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEObjetivosResponse
                var mappedEObjetivos = _mapper.Map<List<GetAllEObjetivosResponse>>(EObjetivoList);

                return Result<List<GetAllEObjetivosResponse>>.Success(mappedEObjetivos);
            }
        }




    }

}
