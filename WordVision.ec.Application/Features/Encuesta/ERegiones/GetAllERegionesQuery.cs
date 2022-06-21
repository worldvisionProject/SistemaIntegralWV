using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.ERegiones
{
    public class GetAllERegionesResponse
    {
        public int Id { get; set; }
        public string reg_nombre { get; set; }

        public virtual List<EProvincia> EProvincias { get; set; }
        public virtual List<EReporteTabulado> EReporteTabulados { get; set; }
    }
    public class GetAllERegionesQuery : IRequest<Result<List<GetAllERegionesResponse>>>
    {
        public GetAllERegionesQuery()
        {
        }
        public class GetAllERegionesQueryHandler : IRequestHandler<GetAllERegionesQuery, Result<List<GetAllERegionesResponse>>>
        {
            private readonly IERegionRepository _eRegion;
            private readonly IMapper _mapper;

            public GetAllERegionesQueryHandler(IERegionRepository eRegion,
                                                    IMapper mapper)
            {
                _eRegion = eRegion;
                _mapper = mapper;

            }

            //Ejecuta el select
            public async Task<Result<List<GetAllERegionesResponse>>> Handle(GetAllERegionesQuery request, CancellationToken cancellationToken)
            {
                //Traemos el listado de registro de la base de dartos
                var ERegionList = await _eRegion.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllERegionesResponse
                var mappedERegiones = _mapper.Map<List<GetAllERegionesResponse>>(ERegionList);

                return Result<List<GetAllERegionesResponse>>.Success(mappedERegiones);
            }
        }




    }


}
