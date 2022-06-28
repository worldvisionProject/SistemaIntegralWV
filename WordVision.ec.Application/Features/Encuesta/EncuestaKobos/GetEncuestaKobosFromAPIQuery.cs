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

    public class GetAllEncuestaKobosFromAPIResponse
    {
        public int Id { get; set; }
        public string enk_Id_string { get; set; }
        public string enk_Title { get; set; }
        public string enk_Description { get; set; }
        public string enk_Url { get; set; }
        public DateTime enk_Fecha { get; set; }
    }


    public class GetAllEncuestaKobosFromAPIQuery : IRequest<Result<List<GetAllEncuestaKobosFromAPIResponse>>>
    {
        public GetAllEncuestaKobosFromAPIQuery()
        {
        }
        public class GetAllEncuestaKobosFromAPIQueryHandler : IRequestHandler<GetAllEncuestaKobosFromAPIQuery, Result<List<GetAllEncuestaKobosFromAPIResponse>>>
        {
            private readonly IEncuestaKoboRepository _encuestaKobo;
            private readonly IMapper _mapper;

            public GetAllEncuestaKobosFromAPIQueryHandler(IEncuestaKoboRepository encuestaKobo, IMapper mapper)
            {
                _encuestaKobo = encuestaKobo;
                _mapper = mapper;

            }

            //Ejecuta el API y devuleve un listado de GetAllEncuestaKobosFromAPIResponse
            public async Task<Result<List<GetAllEncuestaKobosFromAPIResponse>>> Handle(GetAllEncuestaKobosFromAPIQuery request, CancellationToken cancellationToken)
            {
                //Consulta el API que devuelve un listado de EncuestaKobo
                var EncuestaKoboList = await _encuestaKobo.GetKoboAPIAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEncuestaKobosFromAPIResponse
                var mappedEncuestaKobos = _mapper.Map<List<GetAllEncuestaKobosFromAPIResponse>>(EncuestaKoboList);

                return Result<List<GetAllEncuestaKobosFromAPIResponse>>.Success(mappedEncuestaKobos);
            }
        }

    }
}
