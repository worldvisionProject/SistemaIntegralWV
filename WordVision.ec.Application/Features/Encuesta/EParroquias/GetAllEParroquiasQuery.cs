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

namespace WordVision.ec.Application.Features.Encuesta.EParroquias
{
    public class GetAllEParroquiasResponse : GenericResponse
    {
        public string Id { get; set; }
        public string par_nombre { get; set; }


        public string EProgramaId { get; set; }
        public EPrograma EPrograma { get; set; }


        public int ERegionId { get; set; }
        public ERegion ERegion { get; set; }


        public string EProvinciaId { get; set; }
        public EProvincia EProvincia { get; set; }


        public string ECantonId { get; set; }
        public ECanton ECanton { get; set; }


        public string NombreCompleto { get; set; }
        public virtual List<EComunidad> EComunidades { get; set; }
    }
    public class GetAllEParroquiasQuery : GetAllEParroquiasResponse, IRequest<Result<List<GetAllEParroquiasResponse>>>
    {
        public GetAllEParroquiasQuery()
        {
        }
        public class GetAllEParroquiasQueryHandler : IRequestHandler<GetAllEParroquiasQuery, Result<List<GetAllEParroquiasResponse>>>
        {
            private readonly IEParroquiaRepository _eParroquia;
            private readonly IMapper _mapper;

            public GetAllEParroquiasQueryHandler(IEParroquiaRepository eParroquia,
                                                    IMapper mapper)
            {
                _eParroquia = eParroquia;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEParroquiasResponse>>> Handle(GetAllEParroquiasQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                List<EParroquia> EParroquiaList = new();
                if (request.ECantonId != null && request.ECantonId != "")
                    EParroquiaList = await _eParroquia.GetListAsync(request.Include, request.ECantonId);
                else
                    EParroquiaList = await _eParroquia.GetListAsync(request.Include);


                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEParroquiasResponse
                var mappedEParroquias = _mapper.Map<List<GetAllEParroquiasResponse>>(EParroquiaList);

                //Cambiamos el Nombre Completo
                foreach (GetAllEParroquiasResponse fila in mappedEParroquias)
                {
                    fila.NombreCompleto = "(" + fila.Id + ") " + fila.par_nombre;

                    fila.EProvinciaId = fila.ECanton.EProvincia.Id;
                    fila.EProvincia = fila.ECanton.EProvincia;

                    fila.ERegionId = fila.EProvincia.eRegion.Id;
                    fila.ERegion = fila.EProvincia.eRegion;

                }


                return Result<List<GetAllEParroquiasResponse>>.Success(mappedEParroquias);
            }
        }




    }
}
