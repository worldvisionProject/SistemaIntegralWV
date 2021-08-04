using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.FactorCriticoExitoes.Queries.GetById
{
    public class GetFactorCriticoxObjetivoByIdQuery : IRequest<Result<List<GetFactorCriticoExitoByIdResponse>>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdGestion { get; set; }

        public class GetFactorCriticoxObjetivoByIdQueryHandler : IRequestHandler<GetFactorCriticoxObjetivoByIdQuery, Result<List<GetFactorCriticoExitoByIdResponse>>>
        {
            private readonly IFactorCriticoExitoRepository _FactorCriticoExitoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetFactorCriticoxObjetivoByIdQueryHandler(IFactorCriticoExitoRepository FactorCriticoExitoCache, IMapper mapper)
            {
                _FactorCriticoExitoCache = FactorCriticoExitoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetFactorCriticoExitoByIdResponse>>> Handle(GetFactorCriticoxObjetivoByIdQuery query, CancellationToken cancellationToken)
            {
                var FactorCriticoExito = new object();
                if (query.IdColaborador == 0)
                    FactorCriticoExito = await _FactorCriticoExitoCache.GetListxObjetivoAsync(query.Id, query.IdGestion);
                else
                    FactorCriticoExito = await _FactorCriticoExitoCache.GetListxObjetivoAsync(query.Id, query.IdColaborador, query.IdGestion);

                var mappedFactorCriticoExito = _mapper.Map<List<GetFactorCriticoExitoByIdResponse>>(FactorCriticoExito);

                return Result<List<GetFactorCriticoExitoByIdResponse>>.Success(mappedFactorCriticoExito);
            }
        }
    }
}