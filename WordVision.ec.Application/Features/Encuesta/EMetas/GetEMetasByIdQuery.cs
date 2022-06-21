using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EMetas
{
    public class GetEMetasByIdResponse
    {
        public int Id { get; set; }
        public decimal met_valor { get; set; }
        public int EEvaluacionId { get; set; }
        public string EIndicadorId { get; set; }
        public string EProgramaId { get; set; }
    }

    public class GetEMetasByIdQuery : IRequest<Result<GetEMetasByIdResponse>>
    {
        public int Id { get; set; }

        public class GetEMetasByIdQueryHandler : IRequestHandler<GetEMetasByIdQuery, Result<GetEMetasByIdResponse>>
        {
            private readonly IEMetaRepository _eMetasRepository;
            private readonly IMapper _mapper;

            public GetEMetasByIdQueryHandler(IEMetaRepository eMetasRepository, IMapper mapper)
            {
                _eMetasRepository = eMetasRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEMetasByIdResponse>> Handle(GetEMetasByIdQuery query, CancellationToken cancellationToken)
            {
                var EMetaModel = await _eMetasRepository.GetByIdAsync(query.Id);
                var mappedEMetas = _mapper.Map<GetEMetasByIdResponse>(EMetaModel);

                return Result<GetEMetasByIdResponse>.Success(mappedEMetas);
            }
        }

    }




}
