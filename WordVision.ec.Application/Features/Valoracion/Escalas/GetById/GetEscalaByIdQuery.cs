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

namespace WordVision.ec.Application.Features.Valoracion.Escalas.GetById
{
    internal class GetEscalaByIdQuery : IRequest<Result<GetEscalaByIdResponse>>
    {
        public decimal ValorEscala { get; set; }

        public class GetEscalaByIdQueryHandler : IRequestHandler<GetEscalaByIdQuery, Result<GetEscalaByIdResponse>>
        {
            private readonly IEscalaRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetEscalaByIdQueryHandler(IEscalaRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetEscalaByIdResponse>> Handle(GetEscalaByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByValorEscalaAsync(query.ValorEscala);
                var mappedObj = _mapper.Map<GetEscalaByIdResponse>(obj);

                return Result<GetEscalaByIdResponse>.Success(mappedObj);
            }
        }
    }
}
