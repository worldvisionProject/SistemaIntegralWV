using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Queries.GetById
{
    public class GetEstadoPorAnioFiscalByIdQuery : EstadoPorAnioFiscalResponse, IRequest<Result<EstadoPorAnioFiscalResponse>>
    {
    }

    public class GetEstadoPorAnioFiscalByIdQueryHandler : IRequestHandler<GetEstadoPorAnioFiscalByIdQuery, Result<EstadoPorAnioFiscalResponse>>
    {
        private readonly IEstadoPorAnioFiscalRepository _repository;
        private readonly IMapper _mapper;

        public GetEstadoPorAnioFiscalByIdQueryHandler(IEstadoPorAnioFiscalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<EstadoPorAnioFiscalResponse>> Handle(GetEstadoPorAnioFiscalByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<EstadoPorAnioFiscalResponse>(result);

            return Result<EstadoPorAnioFiscalResponse>.Success(response);
        }
    }
}
