using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Presupuesto;

namespace WordVision.ec.Application.Features.Presupuesto.DatosLDR.Queries.GetById
{
   public class GetDatosLDRByIdQuery : IRequest<Result<GetDatosLDRByIdResponse>>
    {
        public int Id { get; set; }
        public class GetDatosLDRByIdQueryHandler : IRequestHandler<GetDatosLDRByIdQuery, Result<GetDatosLDRByIdResponse>>
        {
            private readonly IDatosLDRRepository _firmaCache;
            private readonly IMapper _mapper;

            public GetDatosLDRByIdQueryHandler(IDatosLDRRepository firmaCache, IMapper mapper)
            {
                _firmaCache = firmaCache;
                _mapper = mapper;
            }

            public async Task<Result<GetDatosLDRByIdResponse>> Handle(GetDatosLDRByIdQuery query, CancellationToken cancellationToken)
            {
                var Colaborador = await _firmaCache.GetByIdAsync(query.Id);
                var mappedColaborador = _mapper.Map<GetDatosLDRByIdResponse>(Colaborador);
                return Result<GetDatosLDRByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}
