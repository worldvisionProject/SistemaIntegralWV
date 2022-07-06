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

namespace WordVision.ec.Application.Features.Encuesta.ERegiones
{
    public class GetERegionesByIdResponse : GenericResponse
    {
        public int Id { get; set; }
        public string reg_nombre { get; set; }

        public virtual List<EProvincia> EProvincias { get; set; }
    }

    public class GetERegionesByIdQuery : GetERegionesByIdResponse, IRequest<Result<GetERegionesByIdResponse>>
    {
        public int Id { get; set; }

        public class GetERegionesByIdQueryHandler : IRequestHandler<GetERegionesByIdQuery, Result<GetERegionesByIdResponse>>
        {
            private readonly IERegionRepository _eRegionesRepository;
            private readonly IMapper _mapper;

            public GetERegionesByIdQueryHandler(IERegionRepository eRegionesRepository, IMapper mapper)
            {
                _eRegionesRepository = eRegionesRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetERegionesByIdResponse>> Handle(GetERegionesByIdQuery query, CancellationToken cancellationToken)
            {
                var ERegionModel = await _eRegionesRepository.GetByIdAsync(query.Id);
                var mappedERegiones = _mapper.Map<GetERegionesByIdResponse>(ERegionModel);

                return Result<GetERegionesByIdResponse>.Success(mappedERegiones);
            }
        }

    }



}
