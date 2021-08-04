using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.EstrategiaNacionales.Queries.GetById
{
    public class GetEstrategiaNacionalByIdQuery : IRequest<Result<GetEstrategiaNacionalByIdResponse>>
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int Nivel { get; set; }
        public class GetEstrategiaNacionalByIdQueryHandler : IRequestHandler<GetEstrategiaNacionalByIdQuery, Result<GetEstrategiaNacionalByIdResponse>>
        {
            private readonly IEstrategiaNacionalRepository _EstrategiaNacionalCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;
         
            private readonly IMapper _mapper;

            public GetEstrategiaNacionalByIdQueryHandler( IEstrategiaNacionalRepository EstrategiaNacionalCache, IMapper mapper)
            {
                _EstrategiaNacionalCache = EstrategiaNacionalCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetEstrategiaNacionalByIdResponse>> Handle(GetEstrategiaNacionalByIdQuery query, CancellationToken cancellationToken)
            {
                var EstrategiaNacional = new object();
                if (query.IdColaborador == 0)
                    EstrategiaNacional = await _EstrategiaNacionalCache.GetByIdAsync(query.Id);
                else
                {
                    //switch (query.Nivel)
                    //{
                    //    case 2:
                            EstrategiaNacional = await _EstrategiaNacionalCache.GetByIdAsync(query.Id, query.IdColaborador);
                    //        break;
                    //    case 3:
                    //        EstrategiaNacional = await _EstrategiaNacionalCache.GetByIdxOperativoAsync(query.Id, query.IdColaborador,0);
                    //        break;
                    //    case 4:
                    //        EstrategiaNacional = await _EstrategiaNacionalCache.GetByIdxTacticoAsync(query.Id, query.IdColaborador,0);

                    //        break;
                    //}

                   
                }
                var mappedEstrategiaNacional = _mapper.Map<GetEstrategiaNacionalByIdResponse>(EstrategiaNacional);
                
                return Result<GetEstrategiaNacionalByIdResponse>.Success(mappedEstrategiaNacional);
            }
        }
    }
}