using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.MetaEstrategicas.Queries.GetById
{
    public class GetMetaEstrategicaByIdIndicador : IRequest<Result<List<GetMetaEstrategicaByIdResponse>>>
    {
        public int Id { get; set; }

        public class GetMetaEstrategicaByIdIndicadorHandler : IRequestHandler<GetMetaEstrategicaByIdIndicador, Result<List<GetMetaEstrategicaByIdResponse>>>
        {
            private readonly IMetaEstrategicaRepository _metaEstrategicaRepository;
          
            private readonly IMapper _mapper;

            public GetMetaEstrategicaByIdIndicadorHandler(IMetaEstrategicaRepository metaEstrategicaRepository, IMapper mapper)
            {
                _metaEstrategicaRepository = metaEstrategicaRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetMetaEstrategicaByIdResponse>>> Handle(GetMetaEstrategicaByIdIndicador query, CancellationToken cancellationToken)
            {
                var meta = await _metaEstrategicaRepository.GetListByIdAsync(query.Id);
                var mappedMeta = _mapper.Map<List<GetMetaEstrategicaByIdResponse>>(meta);

                return Result<List<GetMetaEstrategicaByIdResponse>>.Success(mappedMeta);
            }
        }
    }
}
