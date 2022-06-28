using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.ECantones
{
    public class GetAllECantonesResponse
    {
        public string Id { get; set; }
        public string can_nombre { get; set; }
        public string EProvinciaId { get; set; }
        public virtual List<EParroquia> EParroquias { get; set; }
        public virtual List<EReporteTabulado> EReporteTabulados { get; set; }
    }
    public class GetAllECantonesQuery : IRequest<Result<List<GetAllECantonesResponse>>>
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
                var ECantonList = await _eCanton.GetListAsync();

                //Mapeamos la estructura de la base a la estructura deseada tipo GetAllECantonesResponse
                var mappedECantones = _mapper.Map<List<GetAllECantonesResponse>>(ECantonList);

                return Result<List<GetAllECantonesResponse>>.Success(mappedECantones);
            }
        }




    }

}
