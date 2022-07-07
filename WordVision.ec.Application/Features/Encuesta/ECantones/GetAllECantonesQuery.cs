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

namespace WordVision.ec.Application.Features.Encuesta.ECantones
{
    public class GetAllECantonesResponse : GenericResponse
    {
        public string Id { get; set; }
        public string can_nombre { get; set; }
        
        
        public int ERegionId { get; set; }
        public ERegion ERegion { get; set; }

        
        public string EProvinciaId { get; set; }
        public EProvincia EProvincia { get; set; }


        public string NombreCompleto { get; set; }
        public virtual List<EParroquia> EParroquias { get; set; }
    }
    public class GetAllECantonesQuery : GetAllECantonesResponse, IRequest<Result<List<GetAllECantonesResponse>>>
    {
        public GetAllECantonesQuery()
        {
        }
        public class GetAllECantonesQueryHandler : IRequestHandler<GetAllECantonesQuery, Result<List<GetAllECantonesResponse>>>
        {
            private readonly IECantonRepository _eCanton;
            private readonly IMapper _mapper;

            public GetAllECantonesQueryHandler(IECantonRepository eCanton,
                                                    IMapper mapper)
            {
                _eCanton = eCanton;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllECantonesResponse>>> Handle(GetAllECantonesQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                List<ECanton> ECantonList = new();
                if (request.EProvinciaId != null && request.EProvinciaId != "")
                    ECantonList = await _eCanton.GetListAsync(request.Include, request.EProvinciaId);
                else
                    ECantonList = await _eCanton.GetListAsync(request.Include);


                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllECantonesResponse
                var mappedECantones = _mapper.Map<List<GetAllECantonesResponse>>(ECantonList);

                //Cambiamos el Nombre Completo
                foreach (GetAllECantonesResponse fila in mappedECantones)
                {
                    fila.NombreCompleto = "(" + fila.Id + ") " + fila.can_nombre;
                    fila.ERegionId = fila.EProvincia.eRegion.Id;
                    fila.ERegion = fila.EProvincia.eRegion;
                }


                return Result<List<GetAllECantonesResponse>>.Success(mappedECantones);
            }
        }




    }

}
