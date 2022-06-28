using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetAll;
using WordVision.ec.Application.Interfaces.Repositories.Maestro;

namespace WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetById
{
    public class GetRCNinoPatrocinadoByIdQuery : RCNinoPatrocinadoResponse, IRequest<Result<RCNinoPatrocinadoResponse>>
    {

    }

    public class GetRcNinoPatrocinadoByIdQueryHandler : IRequestHandler<GetRCNinoPatrocinadoByIdQuery, Result<RCNinoPatrocinadoResponse>>
    {
        private readonly IRCNinoPatrocinadoRepository _rCNinoPatrocinadoRepository;
        private readonly IMapper _mapper;

        public GetRcNinoPatrocinadoByIdQueryHandler(IRCNinoPatrocinadoRepository rCNinoPatrocinadoRepository, IMapper mapper)
        {
            _rCNinoPatrocinadoRepository = rCNinoPatrocinadoRepository;
            _mapper = mapper;
        }

        public async Task<Result<RCNinoPatrocinadoResponse>> Handle(GetRCNinoPatrocinadoByIdQuery query, CancellationToken cancellationToken)
        {
            var result = await _rCNinoPatrocinadoRepository.GetByIdAsync(query.Id);
            var response = _mapper.Map<RCNinoPatrocinadoResponse>(result);

            return Result<RCNinoPatrocinadoResponse>.Success(response);
        }
    }
}
