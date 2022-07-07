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
    public class GetECantonesByIdResponse : GenericResponse
    {
        public string Id { get; set; }
        public string can_nombre { get; set; }
        public int ERegionId { get; set; }
        public string EProvinciaId { get; set; }
        
        public virtual List<EParroquia> EParroquias { get; set; }
    }

    public class GetECantonesByIdQuery : GetECantonesByIdResponse, IRequest<Result<GetECantonesByIdResponse>>
    {
        public string Id { get; set; }

        public class GetECantonesByIdQueryHandler : IRequestHandler<GetECantonesByIdQuery, Result<GetECantonesByIdResponse>>
        {
            private readonly IECantonRepository _eCantonesRepository;
            private readonly IMapper _mapper;

            public GetECantonesByIdQueryHandler(IECantonRepository eCantonesRepository, IMapper mapper)
            {
                _eCantonesRepository = eCantonesRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetECantonesByIdResponse>> Handle(GetECantonesByIdQuery query, CancellationToken cancellationToken)
            {
                var ECantonModel = await _eCantonesRepository.GetByIdAsync(query.Id);
                var mappedECantones = _mapper.Map<GetECantonesByIdResponse>(ECantonModel);
                
                mappedECantones.ERegionId = ECantonModel.EProvincia.eRegion.Id;

                return Result<GetECantonesByIdResponse>.Success(mappedECantones);
            }
        }

    }


}
