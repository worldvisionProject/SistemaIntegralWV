using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.DipInsumo.Queries.GetById
{
    public class GetDipInsumoByIdQuery : DipInsumoResponse, IRequest<Result<DipInsumoResponse>>
    {
    }

    public class GetDipInsumoByIdQueryHandler : IRequestHandler<GetDipInsumoByIdQuery, Result<DipInsumoResponse>>
    {
        private readonly IDipInsumoRepository _repository;
        private readonly IMapper _mapper;

        public GetDipInsumoByIdQueryHandler(IDipInsumoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<DipInsumoResponse>> Handle(GetDipInsumoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<DipInsumoResponse>(result);

            return Result<DipInsumoResponse>.Success(response);
        }
    }
}
