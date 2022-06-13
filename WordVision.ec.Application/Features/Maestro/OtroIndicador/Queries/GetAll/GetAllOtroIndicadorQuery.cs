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

namespace WordVision.ec.Application.Features.Maestro.OtroIndicador.Queries.GetAll
{
    public class GetAllOtroIndicadorQuery : OtroIndicadorResponse, IRequest<Result<List<OtroIndicadorResponse>>>
    {
    }

    public class GetAllOtroIndicadorQueryHandler : IRequestHandler<GetAllOtroIndicadorQuery, Result<List<OtroIndicadorResponse>>>
    {
        private readonly IOtroIndicadorRepository _repository;
        private readonly IMapper _mapper;

        public GetAllOtroIndicadorQueryHandler(IOtroIndicadorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<OtroIndicadorResponse>>> Handle(GetAllOtroIndicadorQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.OtroIndicador>(request);
            var rcPatrocinadoList = await _repository.GetListAsync(entity);
            var responseList = _mapper.Map<List<OtroIndicadorResponse>>(rcPatrocinadoList);

            return Result<List<OtroIndicadorResponse>>.Success(responseList);
        }
    }
}
