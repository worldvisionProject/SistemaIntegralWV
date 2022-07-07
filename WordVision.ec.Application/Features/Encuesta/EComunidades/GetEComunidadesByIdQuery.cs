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
    public class GetEComunidadesByIdResponse : GenericResponse
    {
        public string Id { get; set; }
        public string com_nombre { get; set; }

        public int ERegionId { get; set; }
        public string EProvinciaId { get; set; }
        public string ECantonId { get; set; }
        public string EParroquiaId { get; set; }

    }

    public class GetEComunidadesByIdQuery : GetEComunidadesByIdResponse, IRequest<Result<GetEComunidadesByIdResponse>>
    {
        public string Id { get; set; }

        public class GetEComunidadesByIdQueryHandler : IRequestHandler<GetEComunidadesByIdQuery, Result<GetEComunidadesByIdResponse>>
        {
            private readonly IEComunidadRepository _eComunidadesRepository;
            private readonly IMapper _mapper;

            public GetEComunidadesByIdQueryHandler(IEComunidadRepository eComunidadesRepository, IMapper mapper)
            {
                _eComunidadesRepository = eComunidadesRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEComunidadesByIdResponse>> Handle(GetEComunidadesByIdQuery query, CancellationToken cancellationToken)
            {
                var EComunidadModel = await _eComunidadesRepository.GetByIdAsync(query.Id);

                var mappedEComunidades = _mapper.Map<GetEComunidadesByIdResponse>(EComunidadModel);

                mappedEComunidades.EParroquiaId = EComunidadModel.eParroquia.Id;
                mappedEComunidades.ECantonId = EComunidadModel.eParroquia.ECanton.Id;
                mappedEComunidades.EProvinciaId = EComunidadModel.eParroquia.ECanton.EProvincia.Id;
                mappedEComunidades.ERegionId = EComunidadModel.eParroquia.ECanton.EProvincia.eRegion.Id;

                return Result<GetEComunidadesByIdResponse>.Success(mappedEComunidades);
            }
        }

    }




}
