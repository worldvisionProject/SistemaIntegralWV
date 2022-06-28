using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.Escalas.Queries.GetAll
{
    public class GetAllEscalaQuery : IRequest<Result<List<GetAllEscalaResponse>>>
    {
       
        public class GetAllEscalaQueryHandler : IRequestHandler<GetAllEscalaQuery, Result<List<GetAllEscalaResponse>>>
        {
            private readonly IEscalaRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetAllEscalaQueryHandler(IEscalaRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetAllEscalaResponse>>> Handle(GetAllEscalaQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListAsync();
                var mappedObj = _mapper.Map<List<GetAllEscalaResponse>>(obj);

                return Result<List<GetAllEscalaResponse>>.Success(mappedObj);
            }
        }
    }
}
