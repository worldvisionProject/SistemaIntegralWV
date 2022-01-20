using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.DTOs.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Competencias.Queries.GetAll
{
    public class GetAllCompetenciasQuery : IRequest<Result<List<CompetenciaResponse>>>
    {
        public int Nivel { get; set; }
        public GetAllCompetenciasQuery()
        {
        }
    }

    public class GetAllCompetenciasQueryHandler : IRequestHandler<GetAllCompetenciasQuery, Result<List<CompetenciaResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICompetenciaRepository _repository;


        public GetAllCompetenciasQueryHandler(ICompetenciaRepository planificacionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = planificacionRepository;
        }



        public async Task<Result<List<CompetenciaResponse>>> Handle(GetAllCompetenciasQuery request, CancellationToken cancellationToken)
        {
            var obj = await _repository.GetListPadreAsync(request.Nivel);
            var mapped = _mapper.Map<List<CompetenciaResponse>>(obj);

            return Result<List<CompetenciaResponse>>.Success(mapped);
        }
    }

}
