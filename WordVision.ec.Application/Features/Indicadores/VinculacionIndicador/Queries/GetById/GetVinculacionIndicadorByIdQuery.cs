using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.VinculacionIndicador.Queries.GetById
{
    public class GetVinculacionIndicadorByIdQuery : VinculacionIndicadorResponse, IRequest<Result<VinculacionIndicadorResponse>>
    {
    }

    public class GetVinculacionIndicadorByIdQueryHandler : IRequestHandler<GetVinculacionIndicadorByIdQuery, Result<VinculacionIndicadorResponse>>
    {
        private readonly IVinculacionIndicadorRepository _repository;
        private readonly IMapper _mapper;

        public GetVinculacionIndicadorByIdQueryHandler(IVinculacionIndicadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<VinculacionIndicadorResponse>> Handle(GetVinculacionIndicadorByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<VinculacionIndicadorResponse>(result);

            return Result<VinculacionIndicadorResponse>.Success(response);
        }
    }
}
