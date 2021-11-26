using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById
{


    public class GetSolicitudByIdAsignadoQuery : IRequest<Result<List<GetSolicitudByIdResponse>>>
    {
        public int Id { get; set; }

        public class GetSolicitudByIdAsignadoQueryHandler : IRequestHandler<GetSolicitudByIdAsignadoQuery, Result<List<GetSolicitudByIdResponse>>>
        {
            private readonly ISolicitudRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetSolicitudByIdAsignadoQueryHandler(ISolicitudRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetSolicitudByIdResponse>>> Handle(GetSolicitudByIdAsignadoQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListSolicitudxAsignadoAsync(query.Id);
                var mappedObj = _mapper.Map<List<GetSolicitudByIdResponse>>(obj);

                return Result<List<GetSolicitudByIdResponse>>.Success(mappedObj);
            }
        }
    }
}
