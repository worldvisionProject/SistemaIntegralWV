using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;

namespace WordVision.ec.Application.Features.Indicadores.EstadoPorAnioFiscal.Queries.GetAll
{
    public class GetAllEstadoPorAnioFiscalQuery : EstadoPorAnioFiscalResponse, IRequest<Result<List<EstadoPorAnioFiscalResponse>>>
    {
    }

    public class GetAllEstadoPorAnioFiscalQueryHandler : IRequestHandler<GetAllEstadoPorAnioFiscalQuery, Result<List<EstadoPorAnioFiscalResponse>>>
    {
        private readonly IEstadoPorAnioFiscalRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEstadoPorAnioFiscalQueryHandler(IEstadoPorAnioFiscalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<EstadoPorAnioFiscalResponse>>> Handle(GetAllEstadoPorAnioFiscalQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Indicadores.EstadoPorAnioFiscal>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<EstadoPorAnioFiscalResponse>>(rcPatrocinadoList);

            return Result<List<EstadoPorAnioFiscalResponse>>.Success(responseList);
        }
    }
}
