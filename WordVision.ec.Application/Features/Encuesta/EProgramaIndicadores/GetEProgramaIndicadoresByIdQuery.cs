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

namespace WordVision.ec.Application.Features.Encuesta.EProgramaIndicadores
{
    public class GetEProgramaIndicadoresByIdResponse : GenericResponse
    {
        public int Id { get; set; }
        public int pi_Poblacion { get; set; }
        public string EIndicadorId { get; set; }
        public string EProgramaId { get; set; }
    }

    public class GetEProgramaIndicadoresByIdQuery : GetEProgramaIndicadoresByIdResponse, IRequest<Result<GetEProgramaIndicadoresByIdResponse>>
    {
        public int Id { get; set; }

        public class GetEProgramaIndicadoresByIdQueryHandler : IRequestHandler<GetEProgramaIndicadoresByIdQuery, Result<GetEProgramaIndicadoresByIdResponse>>
        {
            private readonly IEProgramaIndicadorRepository _eProgramaIndicadoresRepository;
            private readonly IMapper _mapper;

            public GetEProgramaIndicadoresByIdQueryHandler(IEProgramaIndicadorRepository eProgramaIndicadoresRepository, IMapper mapper)
            {
                _eProgramaIndicadoresRepository = eProgramaIndicadoresRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEProgramaIndicadoresByIdResponse>> Handle(GetEProgramaIndicadoresByIdQuery query, CancellationToken cancellationToken)
            {
                var EProgramaIndicadorModel = await _eProgramaIndicadoresRepository.GetByIdAsync(query.Id);
                var mappedEProgramaIndicadores = _mapper.Map<GetEProgramaIndicadoresByIdResponse>(EProgramaIndicadorModel);

                return Result<GetEProgramaIndicadoresByIdResponse>.Success(mappedEProgramaIndicadores);
            }
        }

    }




}
