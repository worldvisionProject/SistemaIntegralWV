using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;

namespace WordVision.ec.Application.Features.Presupuesto.DatosT5.Queries.GetAllCached
{
    public class GetAllDatosT5sCachedQuery : IRequest<Result<List<GetAllDatosT5sCachedResponse>>>
    {
        public GetAllDatosT5sCachedQuery()
        {
        }
    }

    public class GetAllDatosT5sCachedQueryHandler : IRequestHandler<GetAllDatosT5sCachedQuery, Result<List<GetAllDatosT5sCachedResponse>>>
    {
        private readonly IDatosT5Repository _ColaboradorCache;
        private readonly IMapper _mapper;

        public GetAllDatosT5sCachedQueryHandler(IDatosT5Repository ColaboradorCache, IMapper mapper)
        {
            _ColaboradorCache = ColaboradorCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDatosT5sCachedResponse>>> Handle(GetAllDatosT5sCachedQuery request, CancellationToken cancellationToken)
        {
            var ColaboradorList = await _ColaboradorCache.GetListAsync();
            var mappedColaboradores = _mapper.Map<List<GetAllDatosT5sCachedResponse>>(ColaboradorList);
            return Result<List<GetAllDatosT5sCachedResponse>>.Success(mappedColaboradores);
        }
    }
}
