using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EComunidades
{
    public class GetAllEComunidadesResponse : GenericResponse
    {
        public string Id { get; set; }
        public string com_nombre { get; set; }
        public string NombreCompleto { get; set; }


        public int ERegionId { get; set; }
        public ERegion ERegion { get; set; }


        public string EProvinciaId { get; set; }
        public EProvincia EProvincia { get; set; }


        public string ECantonId { get; set; }
        public ECanton ECanton { get; set; }


        public string EParroquiaId { get; set; }
        public EParroquia EParroquia { get; set; }


    }
    public class GetAllEComunidadesQuery : GetAllEComunidadesResponse, IRequest<Result<List<GetAllEComunidadesResponse>>>
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
                List<EComunidad> EComunidadList = new();
                if (request.EParroquiaId != null && request.EParroquiaId != "")
                    EComunidadList = await _eComunidad.GetListAsync(request.Include, request.EParroquiaId);
                else
                    EComunidadList = await _eComunidad.GetListAsync(request.Include);


                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEComunidadesResponse
                var mappedEComunidades = _mapper.Map<List<GetAllEComunidadesResponse>>(EComunidadList);

                //Cambiamos el Nombre Completo
                foreach (GetAllEComunidadesResponse fila in mappedEComunidades)
                {
                    fila.NombreCompleto = "(" + fila.Id + ") " + fila.com_nombre;

                    fila.ECantonId = fila.EParroquia.ECanton.Id;
                    fila.ECanton = fila.EParroquia.ECanton;

                    fila.EProvinciaId = fila.ECanton.EProvincia.Id;
                    fila.EProvincia = fila.ECanton.EProvincia;

                    fila.ERegionId = fila.EProvincia.eRegion.Id;
                    fila.ERegion = fila.EProvincia.eRegion;


                }


                return Result<List<GetAllEComunidadesResponse>>.Success(mappedEComunidades);
            }
        }




    }
}
