using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetAll
{
    public class GetAllFaseProgramaAreaQuery : FaseProgramaAreaResponse, IRequest<Result<List<FaseProgramaAreaResponse>>>
    {
    }

    public class GetAllFaseProgramaAreaQueryHandler : IRequestHandler<GetAllFaseProgramaAreaQuery, Result<List<FaseProgramaAreaResponse>>>
    {
        private readonly IFaseProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllFaseProgramaAreaQueryHandler(IFaseProgramaAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<FaseProgramaAreaResponse>>> Handle(GetAllFaseProgramaAreaQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.FaseProgramaArea>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<FaseProgramaAreaResponse>>(rcPatrocinadoList);

            return Result<List<FaseProgramaAreaResponse>>.Success(responseList);
        }
    }
}
