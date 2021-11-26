using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById
{


    public class GetSolicitudByIdSolicitanteQuery : IRequest<Result<List<GetSolicitudByIdResponse>>>
    {
        public int Id { get; set; }

        public int Tipo { get; set; }

        public class GetSolicitudByIdSolicitanteQueryHandler : IRequestHandler<GetSolicitudByIdSolicitanteQuery, Result<List<GetSolicitudByIdResponse>>>
        {
            private readonly ISolicitudRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetSolicitudByIdSolicitanteQueryHandler(ISolicitudRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetSolicitudByIdResponse>>> Handle(GetSolicitudByIdSolicitanteQuery query, CancellationToken cancellationToken)
            {
                if (query.Tipo == 0)
                {
                    var obj = await _entidadRepository.GetListSolicitudxSolicitanteAsync(query.Id);
                    var mappedObj = _mapper.Map<List<GetSolicitudByIdResponse>>(obj);

                    return Result<List<GetSolicitudByIdResponse>>.Success(mappedObj);
                }
                else
                {
                    var obj = await _entidadRepository.GetListSolicitudxSolicitanteComunicaAsync(query.Id);
                    var mappedObj = _mapper.Map<List<GetSolicitudByIdResponse>>(obj);

                    return Result<List<GetSolicitudByIdResponse>>.Success(mappedObj);
                }

            }
        }
    }
}
