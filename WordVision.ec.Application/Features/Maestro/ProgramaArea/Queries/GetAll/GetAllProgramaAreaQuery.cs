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

namespace WordVision.ec.Application.Features.Maestro.ProgramaArea.Queries.GetAll
{
    public class GetAllProgramaAreaQuery : ProgramaAreaResponse, IRequest<Result<List<ProgramaAreaResponse>>>
    {
    }

    public class GetAllProgramaAreaQueryHandler : IRequestHandler<GetAllProgramaAreaQuery, Result<List<ProgramaAreaResponse>>>
    {
        private readonly IProgramaAreaRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProgramaAreaQueryHandler(IProgramaAreaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProgramaAreaResponse>>> Handle(GetAllProgramaAreaQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.ProgramaArea>(request);
            var list = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<ProgramaAreaResponse>>(list);

            return Result<List<ProgramaAreaResponse>>.Success(responseList);
        }
    }
}
