using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
namespace WordVision.ec.Application.Features.Encuesta.EComunidades
{
    public class GetAllEComunidadesResponse
    {
        public string Id { get; set; }
        public string com_nombre { get; set; }
        public string EParroquiaId { get; set; }

    }
    public class GetAllEComunidadesQuery : IRequest<Result<List<GetAllEComunidadesResponse>>>
    {
        public GetAllEComunidadesQuery()
        {
        }
        public class GetAllEComunidadesQueryHandler : IRequestHandler<GetAllEComunidadesQuery, Result<List<GetAllEComunidadesResponse>>>
        {
            private readonly IEComunidadRepository _eComunidad;
            private readonly IMapper _mapper;

            public GetAllEComunidadesQueryHandler(IEComunidadRepository eComunidad,
                                                    IMapper mapper)
            {
                _eComunidad = eComunidad;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEComunidadesResponse>>> Handle(GetAllEComunidadesQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EComunidadList = await _eComunidad.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEComunidadesResponse
                var mappedEComunidades = _mapper.Map<List<GetAllEComunidadesResponse>>(EComunidadList);

                return Result<List<GetAllEComunidadesResponse>>.Success(mappedEComunidades);
            }
        }




    }
}
