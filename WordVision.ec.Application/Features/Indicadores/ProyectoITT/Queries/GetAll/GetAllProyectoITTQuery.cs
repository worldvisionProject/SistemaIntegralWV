using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITT.Queries.GetAll
{
    public class GetAllProyectoITTQuery : ProyectoITTResponse, IRequest<Result<List<ProyectoITTResponse>>>
    {
    }

    public class GetAllProyectoITTQueryHandler : IRequestHandler<GetAllProyectoITTQuery, Result<List<ProyectoITTResponse>>>
    {
        private readonly IProyectoITTRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProyectoITTQueryHandler(IProyectoITTRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProyectoITTResponse>>> Handle(GetAllProyectoITTQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.ProyectoITT>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ProyectoITTResponse>>(rcPatrocinadoList);

            return Result<List<ProyectoITTResponse>>.Success(responseList);
        }
    }
}
