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

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetById
{
    public class GetLogFrameByIdQuery : LogFrameResponse, IRequest<Result<LogFrameResponse>>
    {
    }

    public class GetLogFrameByIdQueryHandler : IRequestHandler<GetLogFrameByIdQuery, Result<LogFrameResponse>>
    {
        private readonly ILogFrameRepository _repository;
        private readonly IMapper _mapper;

        public GetLogFrameByIdQueryHandler(ILogFrameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<LogFrameResponse>> Handle(GetLogFrameByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id, query.Include);
            var response = _mapper.Map<LogFrameResponse>(result);

            return Result<LogFrameResponse>.Success(response);
        }
    }
}
