using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetById
{
    public class GetOtroIndicadorByIdQuery : OtroIndicadorResponse, IRequest<Result<OtroIndicadorResponse>>
    {
    }

    public class GetOtroIndicadorByIdQueryHandler : IRequestHandler<GetOtroIndicadorByIdQuery, Result<OtroIndicadorResponse>>
    {
        private readonly IOtroIndicadorRepository _repository;
        private readonly IMapper _mapper;

        public GetOtroIndicadorByIdQueryHandler(IOtroIndicadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<OtroIndicadorResponse>> Handle(GetOtroIndicadorByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<OtroIndicadorResponse>(result);

            return Result<OtroIndicadorResponse>.Success(response);
        }
    }
}
