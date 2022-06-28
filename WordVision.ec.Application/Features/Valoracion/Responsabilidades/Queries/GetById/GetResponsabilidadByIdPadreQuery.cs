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
    public class GetResponsabilidadByIdPadreQuery : IRequest<Result<List<GetResponsabilidadByIdResponse>>>
    {
        public int IdPadre { get; set; }

        public class GetResponsabilidadByIdPadreQueryHandler : IRequestHandler<GetResponsabilidadByIdPadreQuery, Result<List<GetResponsabilidadByIdResponse>>>
        {
            private readonly IResponsabilidadRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetResponsabilidadByIdPadreQueryHandler(IResponsabilidadRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetResponsabilidadByIdResponse>>> Handle(GetResponsabilidadByIdPadreQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListxPadreAsync(query.IdPadre);
                var mappedObj = _mapper.Map< List<GetResponsabilidadByIdResponse>>(obj);

                return Result<List<GetResponsabilidadByIdResponse>>.Success(mappedObj);
            }
        }
    }
}
