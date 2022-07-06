using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Donacion;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Donantes.Queries.GetAllCached
{
    public class GetAllDonantesQuery : IRequest<Result<List<GetAllDonantesResponse>>>
    {
        public GetAllDonantesQuery()
        {
        }
        public class GetAllDonantesQueryHandler : IRequestHandler<GetAllDonantesQuery, Result<List<GetAllDonantesResponse>>>
        {
            private readonly IDonanteRepository _donante;
            private readonly IMapper _mapper;


            //Ejecuta el select
            public GetAllDonantesQueryHandler(IDonanteRepository donante, IMapper mapper)
            {
                _donante = donante;
                _mapper = mapper;

            }

            public async Task<Result<List<GetAllDonantesResponse>>> Handle(GetAllDonantesQuery request, CancellationToken cancellationToken)
            {
                var DonanteList = await _donante.GetListAsync();
                var mappedDonantes = _mapper.Map<List<GetAllDonantesResponse>>(DonanteList);

                return Result<List<GetAllDonantesResponse>>.Success(mappedDonantes);
            }
        }
    }
}
