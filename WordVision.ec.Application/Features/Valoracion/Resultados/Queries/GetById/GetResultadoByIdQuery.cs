using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Soporte;
using WordVision.ec.Application.Interfaces.Repositories.Valoracion;

namespace WordVision.ec.Application.Features.Valoracion.PlanificacionResultados.Queries.GetById
{


    public class GetResultadoByIdQuery : IRequest<Result<GetResultadoByIdResponse>>
    {
        public int Id { get; set; }

        public class GetResultadoByIdQueryHandler : IRequestHandler<GetResultadoByIdQuery, Result<GetResultadoByIdResponse>>
        {
            private readonly IResultadoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetResultadoByIdQueryHandler(IResultadoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetResultadoByIdResponse>> Handle(GetResultadoByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetResultadoByIdResponse>(obj);

                return Result<GetResultadoByIdResponse>.Success(mappedObj);
            }
        }
    }
}
