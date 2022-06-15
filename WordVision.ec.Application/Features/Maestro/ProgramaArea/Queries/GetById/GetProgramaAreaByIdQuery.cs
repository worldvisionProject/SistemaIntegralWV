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

namespace WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetById
{
    public class GetProgramaAreaByIdQuery : ProgramaAreaResponse, IRequest<Result<ProgramaAreaResponse>>
    {
    }

    public class GetProgramaAreaByIdQueryHandler : IRequestHandler<GetProgramaAreaByIdQuery, Result<ProgramaAreaResponse>>
    {
        private readonly IProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        public GetProgramaAreaByIdQueryHandler(IProgramaAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<ProgramaAreaResponse>> Handle(GetProgramaAreaByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(query.Id);
            var response = _mapper.Map<ProgramaAreaResponse>(result);

            return Result<ProgramaAreaResponse>.Success(response);
        }
    }
}
