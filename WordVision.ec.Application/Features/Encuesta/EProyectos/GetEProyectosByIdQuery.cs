using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Extensions;
using WordVision.ec.Application.Interfaces.Repositories.Encuesta;
using WordVision.ec.Domain.Entities.Encuesta;

namespace WordVision.ec.Application.Features.Encuesta.EProyectos
{
    public class GetEProyectosByIdResponse : GenericResponse
    {
        public int Id { get; set; }
        public string py_nombre { get; set; }

        public virtual List<EObjetivo> EObjetivos { get; set; }
    }

    public class GetEProyectosByIdQuery : GetEProyectosByIdResponse, IRequest<Result<GetEProyectosByIdResponse>>
    {

        public class GetEProyectosByIdQueryHandler : IRequestHandler<GetEProyectosByIdQuery, Result<GetEProyectosByIdResponse>>
        {
            private readonly IEProyectoRepository _eProyectosRepository;
            private readonly IMapper _mapper;

            public GetEProyectosByIdQueryHandler(IEProyectoRepository eProyectosRepository, IMapper mapper)
            {
                _eProyectosRepository = eProyectosRepository;
                _mapper = mapper;
            }

            //Devuelve todos la información de detalle del registro del Id proporcionado. 
            public async Task<Result<GetEProyectosByIdResponse>> Handle(GetEProyectosByIdQuery query, CancellationToken cancellationToken)
            {
                var EProyectoModel = await _eProyectosRepository.GetByIdAsync(query.Id);
                var mappedEProyectos = _mapper.Map<GetEProyectosByIdResponse>(EProyectoModel);

                return Result<GetEProyectosByIdResponse>.Success(mappedEProyectos);
            }
        }

    }




}
