using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Competencias.Queries.GetById
{
    public class GetCompetenciaByIdQuery : IRequest<Result<GetCompetenciaByIdResponse>>
    {
        public int Id { get; set; }

        public class GetCompetenciaByIdQueryHandler : IRequestHandler<GetCompetenciaByIdQuery, Result<GetCompetenciaByIdResponse>>
        {
            private readonly ICompetenciaRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetCompetenciaByIdQueryHandler(ICompetenciaRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetCompetenciaByIdResponse>> Handle(GetCompetenciaByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetCompetenciaByIdResponse>(obj);

                return Result<GetCompetenciaByIdResponse>.Success(mappedObj);
            }
        }
    }
}
