using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;

namespace WordVision.ec.Application.Features.Soporte.Solicitudes.Queries.GetById
{
  

    public class GetSolicitudByIdEstadoQuery : IRequest<Result<List<GetSolicitudByIdResponse>>>
    {
        public int Id { get; set; }
      
        public class GetSolicitudByIdEstadoQueryHandler : IRequestHandler<GetSolicitudByIdEstadoQuery, Result<List<GetSolicitudByIdResponse>>>
        {
            private readonly ISolicitudRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetSolicitudByIdEstadoQueryHandler(ISolicitudRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetSolicitudByIdResponse>>> Handle(GetSolicitudByIdEstadoQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetListSolicitudxEstadoAsync(query.Id);
                var mappedObj = _mapper.Map< List<GetSolicitudByIdResponse>>(obj);

                return Result< List<GetSolicitudByIdResponse>>.Success(mappedObj);
            }
        }
    }
}
