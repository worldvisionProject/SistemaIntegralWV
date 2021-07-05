using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Respuestas.Queries.GetById
{
    public class GetCountByIdColaboradorQuery : IRequest<Result<int>>
    {
        public int IdColaorador { get; set; }
        public int IdDocumento { get; set; }

        public class GetCountByIdColaboradorQueryHandler : IRequestHandler<GetCountByIdColaboradorQuery, Result<int>>
        {
            private readonly IRespuestaRepository _respestaCache;

            public GetCountByIdColaboradorQueryHandler(IRespuestaRepository respestaCache)
            {
                _respestaCache = respestaCache;
               
            }

            public async Task<Result<int>> Handle(GetCountByIdColaboradorQuery query, CancellationToken cancellationToken)
            {
                var colaborador = await _respestaCache.GetCountByIdColaboradorAsync(query.IdColaorador,query.IdDocumento);
              
                return Result<int>.Success(colaborador);
            }
        }


    }
}
