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
            private readonly ITechoPresupuestarioRepository _techoRepository;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetActividadByIdQueryHandler(ITechoPresupuestarioRepository techoRepository,IActividadRepository actividadRepository, IMapper mapper)
            {
                _actividadRepository = actividadRepository;
                _techoRepository = techoRepository;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetActividadByIdResponse>> Handle(GetActividadByIdQuery query, CancellationToken cancellationToken)
            {
                var actividad = await _actividadRepository.GetByIdAsync(query.Id);
                decimal? totalRecursos = 0;
                decimal? techoRecursos = 0;
                foreach (var rec in actividad.Recursos)
                {
                    totalRecursos = totalRecursos + rec.Total;
                    var techo= await _techoRepository.GetByIdxCentroAsync(rec.CentroCosto.ToString());
                    techoRecursos = techoRecursos + techo?.Techo ?? 0;
                }
                actividad.TotalRecurso = totalRecursos;
                actividad.TechoPresupuestoCC = techoRecursos;
                actividad.Saldo = techoRecursos- totalRecursos;
                var mappedActividad = _mapper.Map<GetActividadByIdResponse>(actividad);

                return Result<GetActividadByIdResponse>.Success(mappedActividad);
            }
        }
    }
}
