using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById
{


    public class GetPonenteByIdQuery : IRequest<Result<GetPonenteByIdResponse>>
    {
        public int Id { get; set; }

        public class GetPonenteByIdQueryHandler : IRequestHandler<GetPonenteByIdQuery, Result<GetPonenteByIdResponse>>
        {
            private readonly IPonenteRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetPonenteByIdQueryHandler(IPonenteRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetPonenteByIdResponse>> Handle(GetPonenteByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetPonenteByIdResponse>(obj);

                return Result<GetPonenteByIdResponse>.Success(mappedObj);
            }
        }
    }
}
