using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EIndicadorUsuarios
{
    public class GetEIndicadorUsuariosByIdResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EIndicadorId { get; set; }
    }

    public class GetEIndicadorUsuariosByIdQuery : IRequest<Result<GetEIndicadorUsuariosByIdResponse>>
    {
        public int Id { get; set; }

        public class GetEIndicadorUsuariosByIdQueryHandler : IRequestHandler<GetEIndicadorUsuariosByIdQuery, Result<GetEIndicadorUsuariosByIdResponse>>
        {
            private readonly IEIndicadorUsuarioRepository _EIndicadorUsuariosRepository;
            private readonly IMapper _mapper;

            public GetEIndicadorUsuariosByIdQueryHandler(IEIndicadorUsuarioRepository EIndicadorUsuariosRepository, IMapper mapper)
            {
                _EIndicadorUsuariosRepository = EIndicadorUsuariosRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEIndicadorUsuariosByIdResponse>> Handle(GetEIndicadorUsuariosByIdQuery query, CancellationToken cancellationToken)
            {
                var EIndicadorUsuarioModel = await _EIndicadorUsuariosRepository.GetByIdAsync(query.Id);
                var mappedEIndicadorUsuarios = _mapper.Map<GetEIndicadorUsuariosByIdResponse>(EIndicadorUsuarioModel);

                return Result<GetEIndicadorUsuariosByIdResponse>.Success(mappedEIndicadorUsuarios);
            }
        }

    }




}
