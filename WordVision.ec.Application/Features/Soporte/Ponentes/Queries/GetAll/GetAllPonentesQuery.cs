using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Ponentes.Queries.GetAll
{
    public class GetAllPonentesQuery : IRequest<Result<List<GetAllPonentesResponse>>>
    {
        public int IdComunicacion { get; set; }
    }
    public class GetAllPonentesQueryHandler : IRequestHandler<GetAllPonentesQuery, Result<List<GetAllPonentesResponse>>>
    {
        private readonly IPonenteRepository _entidad;
        private readonly IMapper _mapper;

        public GetAllPonentesQueryHandler(IPonenteRepository entidad, IMapper mapper)
        {
            _entidad = entidad;
            _mapper = mapper;

        }

        public async Task<Result<List<GetAllPonentesResponse>>> Handle(GetAllPonentesQuery request, CancellationToken cancellationToken)
        {
            var objList = await _entidad.GetListAsync(request.IdComunicacion);
            var mappedObj = _mapper.Map<List<GetAllPonentesResponse>>(objList);

            return Result<List<GetAllPonentesResponse>>.Success(mappedObj);
        }
    }
}
