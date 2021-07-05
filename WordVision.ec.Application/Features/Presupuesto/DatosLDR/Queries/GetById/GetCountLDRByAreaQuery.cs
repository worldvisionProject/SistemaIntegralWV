using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;

namespace WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetById
{
    public class GetCountLDRByAreaQuery : IRequest<Result<int>>
    {
        public string Area { get; set; }
   
        public class GetCountLDRByAreaQueryHandler : IRequestHandler<GetCountLDRByAreaQuery, Result<int>>
        {
            private readonly IDatosLDRRepository _respestaCache;

            public GetCountLDRByAreaQueryHandler(IDatosLDRRepository respestaCache)
            {
                _respestaCache = respestaCache;

            }

            public async Task<Result<int>> Handle(GetCountLDRByAreaQuery query, CancellationToken cancellationToken)
            {
                var colaborador = await _respestaCache.GetCountAreaAsync(query.Area);

                return Result<int>.Success(colaborador);
            }
        }

    }
}
