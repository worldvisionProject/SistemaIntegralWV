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

namespace WordVision.ec.Application.Features.Maestro.RCNinoPatrocinado.Queries.GetAll
{
    public class GetAllRCNinoPatrocinadoQuery : RCNinoPatrocinadoResponse, IRequest<Result<List<RCNinoPatrocinadoResponse>>>
    {
        
    }

    public class GetAllRcNinoPatrocinadoQueryHandler : IRequestHandler<GetAllRCNinoPatrocinadoQuery, Result<List<RCNinoPatrocinadoResponse>>>
    {
        private readonly IRCNinoPatrocinadoRepository _rCNinoPatrocinadoRepository;
        private readonly IMapper _mapper;      

        public GetAllRcNinoPatrocinadoQueryHandler(IRCNinoPatrocinadoRepository rCNinoPatrocinadoRepository, IMapper mapper)
        {
            _rCNinoPatrocinadoRepository = rCNinoPatrocinadoRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<RCNinoPatrocinadoResponse>>> Handle(GetAllRCNinoPatrocinadoQuery request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Maestro.RCNinoPatrocinado>(request);
            var rcPatrocinadoList = await _rCNinoPatrocinadoRepository.GetListAsync(entity);
            var responseList = _mapper.Map<List<RCNinoPatrocinadoResponse>>(rcPatrocinadoList);

            return Result<List<RCNinoPatrocinadoResponse>>.Success(responseList);
        }
    }
}
