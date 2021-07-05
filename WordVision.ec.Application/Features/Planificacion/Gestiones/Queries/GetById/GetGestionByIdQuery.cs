using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById
{
    public class GetGestionByIdQuery : IRequest<Result<GetGestionByIdResponse>>
    {
        public int Id { get; set; }

        public class GetGestionByIdQueryHandler : IRequestHandler<GetGestionByIdQuery, Result<GetGestionByIdResponse>>
        {
            private readonly IGestionRepository _GestionCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;
         
            private readonly IMapper _mapper;

            public GetGestionByIdQueryHandler( IGestionRepository GestionCache, IMapper mapper)
            {
                _GestionCache = GestionCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetGestionByIdResponse>> Handle(GetGestionByIdQuery query, CancellationToken cancellationToken)
            {
                var Gestion = await _GestionCache.GetByIdAsync(query.Id);
                var mappedGestion = _mapper.Map<GetGestionByIdResponse>(Gestion);
                
                return Result<GetGestionByIdResponse>.Success(mappedGestion);
            }
        }
    }
}