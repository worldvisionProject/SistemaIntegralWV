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

namespace WordVision.ec.Application.Features.Planificacion.Recursos.Queries.GetById
{
   
    public class GetRecursoByIdQuery : IRequest<Result<GetRecursoByIdResponse>>
    {


        public int Id { get; set; }

        public class GetRecursoByIdQueryHandler : IRequestHandler<GetRecursoByIdQuery, Result<GetRecursoByIdResponse>>
        {
            private readonly IRecursoRepository _RecursoRepository;
            //private readonly IRespuestaRepository _respuestaCache;
            //private readonly IFormularioRepository _formularioCache;

            private readonly IMapper _mapper;

            public GetRecursoByIdQueryHandler(IRecursoRepository RecursoRepository, IMapper mapper)
            {
                _RecursoRepository = RecursoRepository;
                //_respuestaCache = respuestaCache;
                //_formularioCache = formularioCache;
                _mapper = mapper;
            }

            public async Task<Result<GetRecursoByIdResponse>> Handle(GetRecursoByIdQuery query, CancellationToken cancellationToken)
            {
                var Recurso = await _RecursoRepository.GetByIdAsync(query.Id);
                var mappedRecurso = _mapper.Map<GetRecursoByIdResponse>(Recurso);

                return Result<GetRecursoByIdResponse>.Success(mappedRecurso);
            }
        }
    }



}
