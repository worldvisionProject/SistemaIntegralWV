using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProgramas
{
    public class GetEProgramasByIdResponse
    {
        public string Id { get; set; }
        public string pa_nombre { get; set; }
    }

    public class GetEProgramasByIdQuery : IRequest<Result<GetEProgramasByIdResponse>>
    {
        public string Id { get; set; }

        public class GetEProgramasByIdQueryHandler : IRequestHandler<GetEProgramasByIdQuery, Result<GetEProgramasByIdResponse>>
        {
            private readonly IEProgramaRepository _eProgramasRepository;
            private readonly IMapper _mapper;

            public GetEProgramasByIdQueryHandler(IEProgramaRepository eProgramasRepository, IMapper mapper)
            {
                _eProgramasRepository = eProgramasRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEProgramasByIdResponse>> Handle(GetEProgramasByIdQuery query, CancellationToken cancellationToken)
            {
                var EProgramaModel = await _eProgramasRepository.GetByIdAsync(query.Id);
                var mappedEProgramas = _mapper.Map<GetEProgramasByIdResponse>(EProgramaModel);

                return Result<GetEProgramasByIdResponse>.Success(mappedEProgramas);
            }
        }

    }



}
