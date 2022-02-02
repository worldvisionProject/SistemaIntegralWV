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

namespace WordVision.ec.Application.Features.Planificacion.TiposIndicadores.Queries.GetAll
{
    public class GetAllTiposIndicadoresQuery : IRequest<Result<List<GetAllTiposIndicadoresResponse>>>
    {
        public GetAllTiposIndicadoresQuery()
        {
        }
    }

    public class GetAllTiposIndicadoresQueryHandler : IRequestHandler<GetAllTiposIndicadoresQuery, Result<List<GetAllTiposIndicadoresResponse>>>
    {
        private readonly ITiposIndicadorRepository _tiposIndicador;
        private readonly IMapper _mapper;


        public GetAllTiposIndicadoresQueryHandler(ITiposIndicadorRepository tiposIndicador, IMapper mapper)
        {
            _tiposIndicador = tiposIndicador;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllTiposIndicadoresResponse>>> Handle(GetAllTiposIndicadoresQuery request, CancellationToken cancellationToken)
        {
            var techoPresupuestarioList = await _tiposIndicador.GetListAsync();
            var mappedTiposIndicadores = _mapper.Map<List<GetAllTiposIndicadoresResponse>>(techoPresupuestarioList);
            return Result<List<GetAllTiposIndicadoresResponse>>.Success(mappedTiposIndicadores);
        }
    }
}
