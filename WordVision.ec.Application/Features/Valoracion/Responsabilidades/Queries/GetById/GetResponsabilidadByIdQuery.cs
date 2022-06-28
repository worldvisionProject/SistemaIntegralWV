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

namespace WordVision.ec.Application.Features.Valoracion.Responsabilidades.Queries.GetById
{
    public class GetResponsabilidadByIdQuery : IRequest<Result<GetResponsabilidadByIdResponse>>
    {
        public int Id { get; set; }

        public class GetResponsabilidadByIdQueryHandler : IRequestHandler<GetResponsabilidadByIdQuery, Result<GetResponsabilidadByIdResponse>>
        {
            private readonly IResponsabilidadRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetResponsabilidadByIdQueryHandler(IResponsabilidadRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetResponsabilidadByIdResponse>> Handle(GetResponsabilidadByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetResponsabilidadByIdResponse>(obj);

                return Result<GetResponsabilidadByIdResponse>.Success(mappedObj);
            }
        }
    }
}
