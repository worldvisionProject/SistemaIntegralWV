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

namespace WordVision.ec.Application.Features.Planificacion.IndicadorProductoObjetivos.Queries.GetById
{
  

    public class GetIndicadorProductoObjetivoByIdQuery : IRequest<Result<GetIndicadorProductoObjetivoByIdResponse>>
    {
        public int Id { get; set; }
      
        public class GetIndicadorProductoObjetivoByIdQueryHandler : IRequestHandler<GetIndicadorProductoObjetivoByIdQuery, Result<GetIndicadorProductoObjetivoByIdResponse>>
        {
            private readonly IIndicadorProductoObjetivoRepository _entidadRepository;

            private readonly IMapper _mapper;

            public GetIndicadorProductoObjetivoByIdQueryHandler(IIndicadorProductoObjetivoRepository entidadRepository, IMapper mapper)
            {
                _entidadRepository = entidadRepository;
                _mapper = mapper;
            }

            public async Task<Result<GetIndicadorProductoObjetivoByIdResponse>> Handle(GetIndicadorProductoObjetivoByIdQuery query, CancellationToken cancellationToken)
            {
                var obj = await _entidadRepository.GetByIdAsync(query.Id);
                var mappedObj = _mapper.Map<GetIndicadorProductoObjetivoByIdResponse>(obj);

                return Result<GetIndicadorProductoObjetivoByIdResponse>.Success(mappedObj);
            }
        }
    }
}
