using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;
using WordVision.ec.Domain.Entities.Registro;

namespace WordVision.ec.Application.Features.Registro.Respuestas.Queries.GetById
{
    public class GetByIdColaboradorQuery : IRequest<Result<GetRespuestaByIdResponse>>
    {
        public int IdColaorador { get; set; }
        public int IdDocumento { get; set; }
        public int IdPregunta { get; set; }

        public class GetByIdColaboradorQueryHandler : IRequestHandler<GetByIdColaboradorQuery, Result<GetRespuestaByIdResponse>>
        {
            private readonly IRespuestaRepository _respestaCache;
            private readonly IMapper _mapper;
            public GetByIdColaboradorQueryHandler(IRespuestaRepository respestaCache, IMapper mapper)
            {
                _respestaCache = respestaCache;
                _mapper = mapper;
            }

            public async Task<Result<GetRespuestaByIdResponse>> Handle(GetByIdColaboradorQuery request, CancellationToken cancellationToken)
            {
                var respuesta = await _respestaCache.GetByIdColaboradorAsync(request.IdColaorador, request.IdDocumento,request.IdPregunta);
                var mappedColaborador = _mapper.Map<GetRespuestaByIdResponse>(respuesta);
                return Result<GetRespuestaByIdResponse>.Success(mappedColaborador);
            }

           
        }
    }
}
