using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Features.Planificacion.IndicadorEstrategicoes.Queries.GetById;
using WordVision.ec.Application.Interfaces.Repositories.Planificacion;

namespace WordVision.ec.Application.Features.Planificacion.IndicadorPOAs.Queries.GetById
{

    public class GetIndicadorPOAByIdObjetivoQuery : IRequest<Result<List<GetIndicadorPOAByIdResponse>>>
    {
        public int IdObjetivoEstrategico { get; set; }
        public int IdColaborador { get; set; }

        public class GetIndicadorPOAByIdObjetivoQueryHandler : IRequestHandler<GetIndicadorPOAByIdObjetivoQuery, Result<List<GetIndicadorPOAByIdResponse>>>
        {
            private readonly IIndicadorPOARepository _IndicadorPOARepository;

            private readonly IMapper _mapper;

            public GetIndicadorPOAByIdObjetivoQueryHandler(IIndicadorPOARepository IndicadorPOARepository, IMapper mapper)
            {
                _IndicadorPOARepository = IndicadorPOARepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetIndicadorPOAByIdResponse>>> Handle(GetIndicadorPOAByIdObjetivoQuery query, CancellationToken cancellationToken)
            {
                var meta = await _IndicadorPOARepository.GetListByIdObjetivoAsync(query.IdObjetivoEstrategico, query.IdColaborador);
                var mappedMeta = _mapper.Map<List<GetIndicadorPOAByIdResponse>>(meta);

                return Result<List<GetIndicadorPOAByIdResponse>>.Success(mappedMeta);
            }
        }
    }
}
