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

namespace WordVision.ec.Application.Features.Maestro.ProyectoTecnico.Queries.GetAll
{
    public class GetAllProyectoTecnicoQuery : ProyectoTecnicoResponse, IRequest<Result<List<ProyectoTecnicoResponse>>>
    {
    }

    public class GetAllProyectoTecnicoQueryHandler : IRequestHandler<GetAllProyectoTecnicoQuery, Result<List<ProyectoTecnicoResponse>>>
    {
        private readonly IProyectoTecnicoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProyectoTecnicoQueryHandler(IProyectoTecnicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProyectoTecnicoResponse>>> Handle(GetAllProyectoTecnicoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProyectoTecnico>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ProyectoTecnicoResponse>>(rcPatrocinadoList);

            return Result<List<ProyectoTecnicoResponse>>.Success(responseList);
        }
    }
}
