using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProvincias
{
    public class GetAllEProvinciasResponse
    {
        public string Id { get; set; }
        public string pro_nombre { get; set; }
        public int ERegionId { get; set; }
        public virtual List<ECanton> ECantones { get; set; }
        public virtual List<EReporteTabulado> EReporteTabulados { get; set; }

    }
    public class GetAllEProvinciasQuery : IRequest<Result<List<GetAllEProvinciasResponse>>>
    {
        public GetAllEProvinciasQuery()
        {
        }
        public class GetAllEProvinciasQueryHandler : IRequestHandler<GetAllEProvinciasQuery, Result<List<GetAllEProvinciasResponse>>>
        {
            private readonly IEProvinciaRepository _eProvincia;
            private readonly IMapper _mapper;

            public GetAllEProvinciasQueryHandler(IEProvinciaRepository eProvincia,
                                                    IMapper mapper)
            {
                _eProvincia = eProvincia;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllEProvinciasResponse>>> Handle(GetAllEProvinciasQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var EProvinciaList = await _eProvincia.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllEProvinciasResponse
                var mappedEProvincias = _mapper.Map<List<GetAllEProvinciasResponse>>(EProvinciaList);

                return Result<List<GetAllEProvinciasResponse>>.Success(mappedEProvincias);
            }
        }




    }


}
