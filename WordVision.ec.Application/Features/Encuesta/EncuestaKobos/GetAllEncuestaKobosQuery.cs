using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EncuestaKobos
{

    public class GetAllEncuestaKobosResponse
    {
        public int Id { get; set; }
        public string enk_Id_string { get; set; }
        public string enk_Title { get; set; }
        public string enk_Description { get; set; }
        public string enk_Url { get; set; }
        public DateTime enk_Fecha { get; set; }
        public int NumEncuestados { get; set; }
        public int NumPreguntas { get; set; }
    }

    public class GetAllEncuestaKobosQuery : IRequest<Result<List<GetAllEncuestaKobosResponse>>>
    {
        public GetAllEncuestaKobosQuery()
        {
        }
        public class GetAllEncuestaKobosQueryHandler : IRequestHandler<GetAllEncuestaKobosQuery, Result<List<GetAllEncuestaKobosResponse>>>
        {
            private readonly IEncuestaKoboRepository _encuestaKobo;
            private readonly IEncuestadoKoboRepository _encuestadoKobo;
            private readonly IPreguntaKoboRepository _preguntaKobo;
            private readonly IMapper _mapper;

            public GetAllEncuestaKobosQueryHandler( IEncuestaKoboRepository encuestaKobo, 
                                                    IEncuestadoKoboRepository encuestadoKobo,
                                                    IPreguntaKoboRepository preguntaKobo, 
                                                    IMapper mapper)
            {
                _encuestaKobo = encuestaKobo;
                _encuestadoKobo = encuestadoKobo;
                _preguntaKobo = preguntaKobo;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEncuestaKobosResponse>>> Handle(GetAllEncuestaKobosQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EncuestaKoboList = await _encuestaKobo.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEncuestaKobosResponse
                var mappedEncuestaKobos = _mapper.Map<List<GetAllEncuestaKobosResponse>>(EncuestaKoboList);

                //Consultamos cuantos encuestados tiene cada encuesta 
                foreach(GetAllEncuestaKobosResponse fila in mappedEncuestaKobos)
                {
                    var numEncuestados = await _encuestadoKobo.GetCountAsync(fila.Id);
                    var numPreguntas = await _preguntaKobo.GetCountAsync(fila.Id);
                    fila.NumEncuestados = numEncuestados;  //Conteo de cuantos registros tiene la tabla EncuestadoKobos
                    fila.NumPreguntas = numPreguntas;    //Conteo de cuantos registros tiene la tabla PreguntaKobos

                }


                return Result<List<GetAllEncuestaKobosResponse>>.Success(mappedEncuestaKobos);
            }
        }

    }
}
