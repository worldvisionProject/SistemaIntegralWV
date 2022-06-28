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

namespace WordVision.ec.Application.Features.Planificacion.ObjetivoEstrategicoes.Queries.GetById
{
    public class GetObjetivoNacionalBySeleccionQuery : IRequest<Result<List<GetObjetivoEstrategicoByIdResponse>>>
    {
        public class GetObjetivoNacionalBySeleccionQueryHandler : IRequestHandler<GetObjetivoNacionalBySeleccionQuery, Result<List<GetObjetivoEstrategicoByIdResponse>>>
        {
            private readonly IObjetivoEstrategicoRepository _ObjetivoEstrategicoCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetObjetivoNacionalBySeleccionQueryHandler(IObjetivoEstrategicoRepository ObjetivoEstrategicoCache, IMapper mapper)
            {
                _ObjetivoEstrategicoCache = ObjetivoEstrategicoCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetObjetivoEstrategicoByIdResponse>>> Handle(GetObjetivoNacionalBySeleccionQuery query, CancellationToken cancellationToken)
            {
                var ObjetivoEstrategico = await _ObjetivoEstrategicoCache.GetNacionalAsync();
                var mappedObjetivoEstrategico = _mapper.Map<List<GetObjetivoEstrategicoByIdResponse>>(ObjetivoEstrategico);

                return Result<List<GetObjetivoEstrategicoByIdResponse>>.Success(mappedObjetivoEstrategico);
            }
        }
    }
}
