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
    public class GetEProvinciasByIdResponse
    {
        public string Id { get; set; }
        public string pro_nombre { get; set; }
        public int ERegionId { get; set; }
        public virtual List<ECanton> ECantones { get; set; }
        public virtual List<EReporteTabulado> EReporteTabulados { get; set; }
    }

    public class GetEProvinciasByIdQuery : IRequest<Result<GetEProvinciasByIdResponse>>
    {
        public string Id { get; set; }

        public class GetEProvinciasByIdQueryHandler : IRequestHandler<GetEProvinciasByIdQuery, Result<GetEProvinciasByIdResponse>>
        {
            private readonly IEProvinciaRepository _eProvinciasRepository;
            private readonly IMapper _mapper;

            public GetEProvinciasByIdQueryHandler(IEProvinciaRepository eProvinciasRepository, IMapper mapper)
            {
                _eProvinciasRepository = eProvinciasRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEProvinciasByIdResponse>> Handle(GetEProvinciasByIdQuery query, CancellationToken cancellationToken)
            {
                var EProvinciaModel = await _eProvinciasRepository.GetByIdAsync(query.Id);
                var mappedEProvincias = _mapper.Map<GetEProvinciasByIdResponse>(EProvinciaModel);

                return Result<GetEProvinciasByIdResponse>.Success(mappedEProvincias);
            }
        }

    }

}
