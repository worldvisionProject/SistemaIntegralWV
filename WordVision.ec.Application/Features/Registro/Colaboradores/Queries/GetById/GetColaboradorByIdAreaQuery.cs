using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Colaboradores.Queries.GetById
{
    public class GetColaboradorByIdAreaQuery : IRequest<Result<List<GetColaboradorByIdResponse>>>
    {
        public int Id { get; set; }

        public class GetColaboradorByIdAreaQueryHandler : IRequestHandler<GetColaboradorByIdAreaQuery, Result<List<GetColaboradorByIdResponse>>>
        {
            private readonly IColaboradorRepository _ColaboradorCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;
         
            private readonly IMapper _mapper;

            public GetColaboradorByIdAreaQueryHandler( IColaboradorRepository ColaboradorCache, IMapper mapper)
            {
                _ColaboradorCache = ColaboradorCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetColaboradorByIdResponse>>> Handle(GetColaboradorByIdAreaQuery query, CancellationToken cancellationToken)
            {
                var Colaborador = await _ColaboradorCache.GetByIdAreaAsync(query.Id);
                var mappedColaborador = _mapper.Map<List<GetColaboradorByIdResponse>>(Colaborador);
                
                return Result<List<GetColaboradorByIdResponse>>.Success(mappedColaborador);
            }
        }
    }
}