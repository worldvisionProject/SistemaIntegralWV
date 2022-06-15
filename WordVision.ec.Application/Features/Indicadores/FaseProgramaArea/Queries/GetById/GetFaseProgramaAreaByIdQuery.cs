using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Indicadores;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Indicadores.FaseProgramaArea.Queries.GetById
{
    public class GetFaseProgramaAreaByIdQuery : FaseProgramaAreaResponse, IRequest<Result<FaseProgramaAreaResponse>>
    {
    }

    public class GetFaseProgramaAreaByIdQueryHandler : IRequestHandler<GetFaseProgramaAreaByIdQuery, Result<FaseProgramaAreaResponse>>
    {
        private readonly IFaseProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        public GetFaseProgramaAreaByIdQueryHandler(IFaseProgramaAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<FaseProgramaAreaResponse>> Handle(GetFaseProgramaAreaByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<FaseProgramaAreaResponse>(result);

            return Result<FaseProgramaAreaResponse>.Success(response);
        }
    }
}
