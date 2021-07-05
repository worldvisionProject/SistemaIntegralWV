using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;

namespace WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetAllCached
{
    public class GetAllDatosLDRsCachedQuery : IRequest<Result<List<GetAllDatosLDRsCachedResponse>>>
    {
        public GetAllDatosLDRsCachedQuery()
        {
        }
    }

    public class GetAllDatosLDRsCachedQueryHandler : IRequestHandler<GetAllDatosLDRsCachedQuery, Result<List<GetAllDatosLDRsCachedResponse>>>
    {
        private readonly IDatosLDRRepository _ColaboradorCache;
        private readonly IMapper _mapper;

        public GetAllDatosLDRsCachedQueryHandler(IDatosLDRRepository ColaboradorCache, IMapper mapper)
        {
            _ColaboradorCache = ColaboradorCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDatosLDRsCachedResponse>>> Handle(GetAllDatosLDRsCachedQuery request, CancellationToken cancellationToken)
        {
            var ColaboradorList = await _ColaboradorCache.GetListAsync();
            var mappedColaboradores = _mapper.Map<List<GetAllDatosLDRsCachedResponse>>(ColaboradorList);
            return Result<List<GetAllDatosLDRsCachedResponse>>.Success(mappedColaboradores);
        }
    }
}
