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
    public class GetCompetenciaByIdPadreQuery : IRequest<Result<List<GetCompetenciaByIdResponse>>>
    {
        public int IdPadre { get; set; }

        public class GetCompetenciaByIdPadreQueryHandler : IRequestHandler<GetCompetenciaByIdPadreQuery, Result<List<GetCompetenciaByIdResponse>>>
        {
            private readonly ICompetenciaRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetCompetenciaByIdPadreQueryHandler(ICompetenciaRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetCompetenciaByIdResponse>>> Handle(GetCompetenciaByIdPadreQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListxPadreAsync(query.IdPadre);
                var mappedObj = _mapper.Map< List<GetCompetenciaByIdResponse>>(obj);

                return Result<List<GetCompetenciaByIdResponse>>.Success(mappedObj);
            }
        }
    }
}
