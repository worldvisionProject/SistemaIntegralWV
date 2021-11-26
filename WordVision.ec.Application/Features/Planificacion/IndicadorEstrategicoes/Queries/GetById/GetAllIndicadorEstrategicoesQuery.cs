
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById
{
    public class GetAllIndicadorEstrategicoesQuery : IRequest<Result<List<GetIndicadorEstrategicoByIdResponse>>>
    {
        public int IdObjetivoEstrategico { get; set; }
        public int IdColaborador { get; set; }
        public GetAllIndicadorEstrategicoesQuery()
        {
        }
    }

    public class GetAllIndicadorEstrategicoesQueryHandler : IRequestHandler<GetAllIndicadorEstrategicoesQuery, Result<List<GetIndicadorEstrategicoByIdResponse>>>
    {
        private readonly IIndicadorEstrategicoRepository _IndicadorEstrategicoCache;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllIndicadorEstrategicoesQueryHandler(IRespuestaRepository respuestaCache, IFormularioRepository formularioCache, IIndicadorEstrategicoRepository IndicadorEstrategicoCache, IMapper mapper)
        {
            _IndicadorEstrategicoCache = IndicadorEstrategicoCache;
            _mapper = mapper;
            _respuestaCache = respuestaCache;
            _formularioCache = formularioCache;
        }

        public async Task<Result<List<GetIndicadorEstrategicoByIdResponse>>> Handle(GetAllIndicadorEstrategicoesQuery request, CancellationToken cancellationToken)
        {
            var IndicadorEstrategicoList = await _IndicadorEstrategicoCache.GetListxObjetivoAsync(request.IdObjetivoEstrategico, request.IdColaborador);
            var mappedIndicadorEstrategicoes = _mapper.Map<List<GetIndicadorEstrategicoByIdResponse>>(IndicadorEstrategicoList);

            return Result<List<GetIndicadorEstrategicoByIdResponse>>.Success(mappedIndicadorEstrategicoes);
        }
    }
}