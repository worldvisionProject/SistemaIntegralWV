
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.TechoPresupuestarios.Queries.GetAllCached
{
    public class GetAllTechoPresupuestariosQuery : IRequest<Result<List<GetAllTechoPresupuestariosResponse>>>
    {
        public GetAllTechoPresupuestariosQuery()
        {
        }
    }

    public class GetAllTechoPresupuestariosQueryHandler : IRequestHandler<GetAllTechoPresupuestariosQuery, Result<List<GetAllTechoPresupuestariosResponse>>>
    {
        private readonly ITechoPresupuestarioRepository _techoPresupuestario;
        private readonly IMapper _mapper;
        private readonly IRespuestaRepository _respuestaCache;
        private readonly IFormularioRepository _formularioCache;


        public GetAllTechoPresupuestariosQueryHandler(ITechoPresupuestarioRepository techoPresupuestario, IMapper mapper)
        {
            _techoPresupuestario = techoPresupuestario;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllTechoPresupuestariosResponse>>> Handle(GetAllTechoPresupuestariosQuery request, CancellationToken cancellationToken)
        {
            var techoPresupuestarioList = await _techoPresupuestario.GetListAsync();
            var mappedTechoPresupuestarios = _mapper.Map<List<GetAllTechoPresupuestariosResponse>>(techoPresupuestarioList);
            return Result<List<GetAllTechoPresupuestariosResponse>>.Success(mappedTechoPresupuestarios);
        }
    }
}