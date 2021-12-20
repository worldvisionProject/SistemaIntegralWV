using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetById
{


    public class GetIndicadorByIdProductoObjetivoQuery : IRequest<Result<GetIndicadorProductoObjetivoByIdResponse>>
    {
        public int idProductoObjetivo { get; set; }

        public class GetIndicadorByIdProductoObjetivoQueryHandler : IRequestHandler<GetIndicadorByIdProductoObjetivoQuery, Result<GetIndicadorProductoObjetivoByIdResponse>>
        {
            private readonly IIndicadorProductoObjetivoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetIndicadorByIdProductoObjetivoQueryHandler(IIndicadorProductoObjetivoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetIndicadorProductoObjetivoByIdResponse>> Handle(GetIndicadorByIdProductoObjetivoQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.idProductoObjetivo);
                var mappedObj = _mapper.Map<GetIndicadorProductoObjetivoByIdResponse>(obj);

                return Result<GetIndicadorProductoObjetivoByIdResponse>.Success(mappedObj);
            }
        }
    }
}
