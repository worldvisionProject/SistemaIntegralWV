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

namespace WordVision.ec.Application.Features.Maestro.LogFrame.Queries.GetAll
{
    public class GetAllLogFrameQuery : LogFrameResponse, IRequest<Result<List<LogFrameResponse>>>
    {
    }

    public class GetAllLogFrameQueryHandler : IRequestHandler<GetAllLogFrameQuery, Result<List<LogFrameResponse>>>
    {
        private readonly ILogFrameRepository _repository;
        private readonly IMapper _mapper;

        public GetAllLogFrameQueryHandler(ILogFrameRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<LogFrameResponse>>> Handle(GetAllLogFrameQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.LogFrame>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<LogFrameResponse>>(list);

            return Result<List<LogFrameResponse>>.Success(responseList);
        }
    }
}
