using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.CacheRepositories;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Planificacion.Gestiones.Queries.GetById
{
    public class GetListGestionByIdQuery : IRequest<Result<List<GetGestionByIdResponse>>>
    {
        public int Id { get; set; }

        public class GetListGestionByIdQueryHandler : IRequestHandler<GetListGestionByIdQuery, Result<List<GetGestionByIdResponse>>>
        {
            private readonly IGestionRepository _GestionCache;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;
         
            private readonly IMapper _mapper;

            public GetListGestionByIdQueryHandler( IGestionRepository GestionCache, IMapper mapper)
            {
                _GestionCache = GestionCache;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<List<GetGestionByIdResponse>>> Handle(GetListGestionByIdQuery query, CancellationToken cancellationToken)
            {
                var Gestion = await _GestionCache.GetListByIdAsync(query.Id);
                var mappedGestion = _mapper.Map<List<GetGestionByIdResponse>>(Gestion);
                
                return Result<List<GetGestionByIdResponse>>.Success(mappedGestion);
            }
        }
    }
}