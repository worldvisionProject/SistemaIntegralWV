using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetById
{
    public class GetProyectoTecnicoByIdQuery : ProyectoTecnicoResponse, IRequest<Result<ProyectoTecnicoResponse>>
    {
    }

    public class GetProyectoTecnicoByIdQueryHandler : IRequestHandler<GetProyectoTecnicoByIdQuery, Result<ProyectoTecnicoResponse>>
    {
        private readonly IProyectoTecnicoRepository _proyectoTecnicoRepository;
        private readonly IMapper _mapper;

        public GetProyectoTecnicoByIdQueryHandler(IProyectoTecnicoRepository proyectoTecnicoRepository, IMapper mapper)
        {
            _proyectoTecnicoRepository = proyectoTecnicoRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProyectoTecnicoResponse>> Handle(GetProyectoTecnicoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _proyectoTecnicoRepository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ProyectoTecnicoResponse>(result);

            return Result<ProyectoTecnicoResponse>.Success(response);
        }
    }
}
