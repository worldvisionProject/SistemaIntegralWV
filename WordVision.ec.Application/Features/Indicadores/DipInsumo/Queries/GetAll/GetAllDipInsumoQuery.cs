using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.DipInsumo.Queries.GetAll
{
    public class GetAllDipInsumoQuery : DipInsumoResponse, IRequest<Result<List<DipInsumoResponse>>>
    {
    }

    public class GetAllDipInsumoQueryHandler : IRequestHandler<GetAllDipInsumoQuery, Result<List<DipInsumoResponse>>>
    {
        private readonly IDipInsumoRepository _repository;
        private readonly IMapper _mapper;

        public GetAllDipInsumoQueryHandler(IDipInsumoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<DipInsumoResponse>>> Handle(GetAllDipInsumoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.DipInsumo>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<DipInsumoResponse>>(rcPatrocinadoList);

            return Result<List<DipInsumoResponse>>.Success(responseList);
        }
    }
}
