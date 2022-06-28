using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetAll
{
    public class GetAllVinculacionIndicadorQuery : VinculacionIndicadorResponse, IRequest<Result<List<VinculacionIndicadorResponse>>>
    {
    }

    public class GetAllVinculacionIndicadorQueryHandler : IRequestHandler<GetAllVinculacionIndicadorQuery, Result<List<VinculacionIndicadorResponse>>>
    {
        private readonly IVinculacionIndicadorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllVinculacionIndicadorQueryHandler(IVinculacionIndicadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<VinculacionIndicadorResponse>>> Handle(GetAllVinculacionIndicadorQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.VinculacionIndicador>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<VinculacionIndicadorResponse>>(rcPatrocinadoList);

            return Result<List<VinculacionIndicadorResponse>>.Success(responseList);
        }
    }
}
