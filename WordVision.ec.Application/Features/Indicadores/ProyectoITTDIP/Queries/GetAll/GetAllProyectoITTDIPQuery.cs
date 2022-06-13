using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.ProyectoITTDIP.Queries.GetAll
{
    public class GetAllProyectoITTDIPQuery : ProyectoITTDIPResponse, IRequest<Result<List<ProyectoITTDIPResponse>>>
    {
    }

    public class GetAllProyectoITTDIPQueryHandler : IRequestHandler<GetAllProyectoITTDIPQuery, Result<List<ProyectoITTDIPResponse>>>
    {
        private readonly IProyectoITTDIPRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProyectoITTDIPQueryHandler(IProyectoITTDIPRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProyectoITTDIPResponse>>> Handle(GetAllProyectoITTDIPQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.ProyectoITTDIP>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ProyectoITTDIPResponse>>(rcPatrocinadoList);

            return Result<List<ProyectoITTDIPResponse>>.Success(responseList);
        }
    }
}
