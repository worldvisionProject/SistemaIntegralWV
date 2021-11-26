using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById
{


    public class GetSolicitudByIdQuery : IRequest<Result<GetSolicitudByIdResponse>>
    {
        public int Id { get; set; }

        public class GetSolicitudByIdQueryHandler : IRequestHandler<GetSolicitudByIdQuery, Result<GetSolicitudByIdResponse>>
        {
            private readonly ISolicitudRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetSolicitudByIdQueryHandler(ISolicitudRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetSolicitudByIdResponse>> Handle(GetSolicitudByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetSolicitudByIdResponse>(obj);

                return Result<GetSolicitudByIdResponse>.Success(mappedObj);
            }
        }
    }
}
