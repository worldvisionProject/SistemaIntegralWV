using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WordVision.ec.Application.Interfaces.Repositories.Registro;

namespace WordVision.ec.Application.Features.Registro.Firma.Queries.GetById
{
    public class GetFirmaByIdQuery : IRequest<Result<GetFirmaByIdResponse>>
    {
        public int IdColaborador { get; set; }
        public int IdDocumento { get; set; }

        public class GetFirmaByIdQueryHandler : IRequestHandler<GetFirmaByIdQuery, Result<GetFirmaByIdResponse>>
        {
            private readonly IFirmaRepository _firmaCache;
            private readonly IMapper _mapper;

            public GetFirmaByIdQueryHandler(IFirmaRepository firmaCache, IMapper mapper)
            {
                _firmaCache = firmaCache;
                _mapper = mapper;
            }

            public async Task<Result<GetFirmaByIdResponse>> Handle(GetFirmaByIdQuery query, CancellationToken cancellationToken)
            {
                var Colaborador = await _firmaCache.GetByIdColaboradorAsync(query.IdColaborador, query.IdDocumento);
                var mappedColaborador = _mapper.Map<GetFirmaByIdResponse>(Colaborador);
                return Result<GetFirmaByIdResponse>.Success(mappedColaborador);
            }
        }
    }
}
