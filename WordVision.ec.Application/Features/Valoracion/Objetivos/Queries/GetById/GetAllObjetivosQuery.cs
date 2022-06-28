using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById;
using WordVision.ec.Application.Interfaces.CacheRepositories.Valoracion;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Planificacion.Objetivos.Queries.GetAllCached
{
    public class GetAllObjetivosQuery : IRequest<Result<List<GetObjetivoByIdResponse>>>
    {
         public int IdAnioFiscal { get; set; }
    }

    public class GetAllObjetivosQueryHandler : IRequestHandler<GetAllObjetivosQuery, Result<List<GetObjetivoByIdResponse>>>
    {
        private readonly IObjetivoCacheRepository _objetivoCache;
        private readonly IMapper _mapper;
        public GetAllObjetivosQueryHandler(IObjetivoCacheRepository objetivoCache, IMapper mapper)
        {
            _objetivoCache = objetivoCache;
            _mapper = mapper;

        }

        public async Task<Result<List<GetObjetivoByIdResponse>>> Handle(GetAllObjetivosQuery request, CancellationToken cancellationToken)
        {
            var ObjetivoList = await _objetivoCache.GetCachedListxAnioFiscalAsync(request.IdAnioFiscal);
            var mappedObjetivos = _mapper.Map<List<GetObjetivoByIdResponse>>(ObjetivoList);

            return Result<List<GetObjetivoByIdResponse>>.Success(mappedObjetivos);
        }
    }
}
