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

namespace WordVision.ec.Application.Features.Planificacion.Seguimientos.Queries.GetById
{
    public class GetSeguimientoByIdIndicador : IRequest<Result<List<GetSeguimientoByIdResponse>>>
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public class GetSeguimientoByIdIndicadorHandler : IRequestHandler<GetSeguimientoByIdIndicador, Result<List<GetSeguimientoByIdResponse>>>
        {
            private readonly ISeguimientoRepository _SeguimientoRepository;
          
            private readonly IMapper _mapper;

            public GetSeguimientoByIdIndicadorHandler(ISeguimientoRepository SeguimientoRepository, IMapper mapper)
            {
                _SeguimientoRepository = SeguimientoRepository;
                _mapper = mapper;
            }

            public async Task<Result<List<GetSeguimientoByIdResponse>>> Handle(GetSeguimientoByIdIndicador query, CancellationToken cancellationToken)
            {
                var meta = await _SeguimientoRepository.GetListByIdicadorAsync(query.Id,query.Tipo);
                var mappedMeta = _mapper.Map<List<GetSeguimientoByIdResponse>>(meta);

                return Result<List<GetSeguimientoByIdResponse>>.Success(mappedMeta);
            }
        }
    }
}
