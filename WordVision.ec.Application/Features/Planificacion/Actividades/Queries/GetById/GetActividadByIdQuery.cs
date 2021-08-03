using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.Actividades.Queries.GetById
{
    public class GetActividadByIdQuery : IRequest<Result<GetActividadByIdResponse>>
    {


        public int Id { get; set; }

        public class GetActividadByIdQueryHandler : IRequestHandler<GetActividadByIdQuery, Result<GetActividadByIdResponse>>
        {
            private readonly IActividadRepository _actividadRepository;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetActividadByIdQueryHandler(IActividadRepository actividadRepository, IMapper mapper)
            {
                _actividadRepository = actividadRepository;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetActividadByIdResponse>> Handle(GetActividadByIdQuery query, CancellationToken cancellationToken)
            {
                var actividad = await _actividadRepository.GetByIdAsync(query.Id);
                var mappedActividad = _mapper.Map<GetActividadByIdResponse>(actividad);

                return Result<GetActividadByIdResponse>.Success(mappedActividad);
            }
        }
    }
}
